using System;

using System.Diagnostics;
using System.Threading;
using System.Xml;

using Kixeye.Jabber.Net;
using Kixeye.Bedrock.Collections;
using Kixeye.Bedrock.Util;

using Kixeye.Jabber.Connection;
using Kixeye.Jabber.Protocol;
using Kixeye.Jabber.Protocol.Accept;
using Kixeye.Jabber.Protocol.Stream;

namespace Kixeye.Jabber.Server
{
    /// <summary>
    /// Type of connection to the server, with respect to jabberd.
    /// This list will grow over time to include
    /// queued connections, direct (in-proc) connections, etc.
    /// </summary>
    public enum ComponentType
    {
        /// <summary>
        /// Jabberd will accept the connetion; the component will
        /// initiate the connection.  </summary>
        Accept,
        /// <summary>
        /// Jabberd will connect to the component; jabberd will
        /// initiate the connection.  </summary>
        Connect
    }

    /// <summary>
    /// Received a route element
    /// </summary>
    public delegate void RouteHandler(object sender, Kixeye.Jabber.Protocol.Accept.Route route);

    /// <summary>
    /// Received an XDB element.
    /// </summary>
    public delegate void XdbHandler(object sender, Kixeye.Jabber.Protocol.Accept.Xdb xdb);

    /// <summary>
    /// Received a Log element.
    /// </summary>
    public delegate void LogHandler(object sender, Kixeye.Jabber.Protocol.Accept.Log log);

    /// <summary>
    /// Summary description for ServerComponent.
    /// </summary>
    public class JabberService : Kixeye.Jabber.Connection.XmppStream
    {
        private static readonly OptionHash DEFAULTS = new OptionHash()
        {
            {Options.COMPONENT_DIRECTION, ComponentType.Accept},
            {Options.PORT, 7400},
            {Options.OVERRIDE_FROM, null}
        };

        /// <summary>
        /// Create a a connect component.
        /// </summary>
        public JabberService() : base()
        {
            SetOptions(DEFAULTS);

            this.OnStreamInit += new Kixeye.Jabber.Connection.StreamHandler(JabberService_OnStreamInit);
            this.OnSASLStart += new Kixeye.Jabber.Connection.SASL.SASLProcessorHandler(JabberService_OnSASLStart);
        }

        /// <summary>
        /// Create an accept component.  (Component connects to server)
        /// </summary>
        /// <param name="host">Jabberd host to connect to</param>
        /// <param name="port">Jabberd port to connect to</param>
        /// <param name="name">Component name</param>
        /// <param name="secret">Component secret</param>
        public JabberService(string host,
            int port,
            string name,
            string secret) : this()
        {
            this.ComponentID = name;
            this.NetworkHost = host;
            this.Port = port;

            this[Options.PASSWORD] = secret;
            this[Options.COMPONENT_DIRECTION] = ComponentType.Accept;
        }

        /// <summary>
        /// Create a connect component. (Server connects to component)
        /// </summary>
        /// <param name="port">Port jabberd will connect to</param>
        /// <param name="name">Component name</param>
        /// <param name="secret">Component secret</param>
        public JabberService(int port, string name, string secret) : this()
        {
            this.ComponentID = name;
            this.Port = port;

            this[Options.PASSWORD] = secret;
            this[Options.COMPONENT_DIRECTION] = ComponentType.Connect;
        }

        /// <summary>
        /// We received a route packet.
        /// </summary>
        public event RouteHandler OnRoute;

        /// <summary>
        /// We received an XDB packet.
        /// </summary>
        public event XdbHandler OnXdb;

        /// <summary>
        /// We received a Log packet.
        /// </summary>
        public event LogHandler OnLog;

        /// <summary>
        /// The service name.  Needs to be in the id attribute in the
        /// jabber.xml file.  </summary>
        public string ComponentID
        {
            get { return (string)this[Options.TO]; }
            set
            {
                this[Options.JID] = value;
                this[Options.TO] = value;
            }
        }

        /// <summary>
        /// Component secret.
        /// </summary>
        public string Secret
        {
            get { return (string)this[Options.PASSWORD]; }
            set { this[Options.PASSWORD] = value; }
        }

        /// <summary>
        /// Is this an outgoing connection (base_accept), or an incoming
        /// connection (base_connect).
        /// </summary>
        public ComponentType Type
        {
            get { return (ComponentType)this[Options.COMPONENT_DIRECTION]; }
            set
            {
                if ((ComponentType)this[Options.COMPONENT_DIRECTION] != value)
                {
                    this[Options.COMPONENT_DIRECTION] = value;
                    if ((ComponentType)this[Options.COMPONENT_DIRECTION] == ComponentType.Connect)
                    {
                        this.AutoReconnect = 0;
                    }
                }
            }
        }

        /// <summary>
        /// The stream namespace for this connection.
        /// </summary>
        protected override string NS
        {
            get
            {
                return (this.Type == ComponentType.Accept) ? URI.ACCEPT : URI.CONNECT;
            }
        }

        /// <summary>
        /// Override the from address that is stamped on all outbound stanzas that 
        /// have no from address.
        /// </summary>
        public JID OverrideFrom
        {
            get { return this[Options.OVERRIDE_FROM] as JID; }
            set { this[Options.OVERRIDE_FROM] = value; }
        }

        /// <summary>
        /// Connect to the jabberd, or wait for it to connect to us.
        /// Either way, this call returns immediately.
        /// </summary>
        /// <param name="address">The address to connect to.</param>
        public void Connect(Kixeye.Jabber.Net.Address address)
        {
            this.NetworkHost = address.Hostname;
            this.Port = address.Port;

            Connect();
        }

        /// <summary>
        /// Connect to the jabberd, or wait for it to connect to us.
        /// Either way, this call returns immediately.
        /// </summary>
        public override void Connect()
        {
            this[Options.SERVER_ID] = this[Options.NETWORK_HOST];
            this[Options.JID] = new JID((string)this[Options.TO]);
            if (this.Type == ComponentType.Accept)
                base.Connect();
            else
            {
                Accept();
            }
        }

        /// <summary>
        /// Make sure there's a from address, then write the stanza.
        /// </summary>
        /// <param name="elem">The stanza to write</param>
        public override void Write(XmlElement elem)
        {
            if (State == RunningState.Instance)
            {
                if (elem.GetAttribute("from") == "")
                {
                    JID from = this[Options.OVERRIDE_FROM] as JID;
                    if (from == null)
                        from = this.ComponentID;

                    elem.SetAttribute("from", from);
                }
            }
            base.Write(elem);
        }

        /// <summary>
        /// Got the stream:stream.  Start the handshake.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="tag"></param>
        protected override void OnDocumentStart(object sender, System.Xml.XmlElement tag)
        {
            base.OnDocumentStart(sender, tag);
            if (this.Type == ComponentType.Connect)
            {
                lock (StateLock)
                {
                    State = HandshakingState.Instance;
                }

                Kixeye.Jabber.Protocol.Stream.Stream str = new Kixeye.Jabber.Protocol.Stream.Stream(this.Document, NS);
                str.To = this.ComponentID;
                this.StreamID = str.ID;
                if (ServerVersion.StartsWith("1."))
                    str.Version = "1.0";


                WriteStartTag(str);

                if (ServerVersion.StartsWith("1."))
                {
                    Features f = new Features(this.Document);
                    if (AutoStartTLS && !SSLon && (this[Options.LOCAL_CERTIFICATE] != null))
                        f.StartTLS = new StartTLS(this.Document);
                    Write(f);
                }
            }
        }

        private void Handshake(System.Xml.XmlElement tag)
        {
            Handshake hs = tag as Handshake;

            if (hs == null)
            {
                FireOnError(new System.Security.SecurityException("Bad protocol.  Needs handshake, got: " + tag.OuterXml));
                return;
            }

            if (this.Type == ComponentType.Accept)
                IsAuthenticated = true;
            else
            {
                string test = hs.Digest;
                string good = Element.ShaHash(StreamID, this.Secret);
                if (test == good)
                {
                    IsAuthenticated = true;
                    Write(new Handshake(this.Document));
                }
                else
                {
                    Write(new Error(this.Document));
                    FireOnError(new System.Security.SecurityException("Bad handshake."));
                }
            }
        }

        /// <summary>
        /// Received an element.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="tag"></param>
        protected override void OnElement(object sender, System.Xml.XmlElement tag)
        {
            lock (StateLock)
            {
                StartTLS start = tag as StartTLS;
                if (start != null)
                {
                    State = ConnectedState.Instance;
                    InitializeStream();
                    this.Write(new Proceed(this.Document));
                    this.StartTLS();
                    return;
                }
                if (State == HandshakingState.Instance)
                {
                    // sets IsConnected
                    Handshake(tag);
                    return;
                }
            }

            base.OnElement(sender, tag);

            if (OnRoute != null)
            {
                Route route = tag as Route;
                if (route != null)
                {
                    OnRoute(this, route);
                }
            }
            // TODO: add XdbTracker stuff
            if (OnXdb != null)
            {
                Xdb xdb = tag as Xdb;
                if (xdb != null)
                {
                    OnXdb(this, xdb);
                }
            }
            if (OnLog != null)
            {
                Log log = tag as Log;
                if (log != null)
                {
                    OnLog(this, log);
                }
            }
        }

        private void JabberService_OnSASLStart(object sender, Kixeye.Jabber.Connection.SASL.SASLProcessor proc)
        {
            Kixeye.Jabber.Connection.BaseState s = null;
            lock (StateLock)
            {
                s = State;
            }

            if (s == Kixeye.Jabber.Connection.NonSASLAuthState.Instance)
            {
                lock (StateLock)
                {
                    State = HandshakingState.Instance;
                }

                if (this.Type == ComponentType.Accept)
                {
                    Handshake hand = new Handshake(this.Document);
                    hand.SetAuth(this.Secret, StreamID);
                    Write(hand);
                }
            }
        }

        private void JabberService_OnStreamInit(Object sender, ElementStream stream)
        {
            stream.AddFactory(new Kixeye.Jabber.Protocol.Accept.Factory());
        }
    }

    /// <summary>
    /// Waiting for handshake result.
    /// </summary>
    public class HandshakingState : Kixeye.Jabber.Connection.BaseState
    {
        /// <summary>
        /// The instance that is always used.
        /// </summary>
        public static readonly Kixeye.Jabber.Connection.BaseState Instance = new HandshakingState();
    }

    /// <summary>
    /// Waiting for socket connection.
    /// </summary>
    public class AcceptingState : Kixeye.Jabber.Connection.BaseState
    {
        /// <summary>
        /// The instance that is always used.
        /// </summary>
        public static readonly Kixeye.Jabber.Connection.BaseState Instance = new AcceptingState();
    }
}
