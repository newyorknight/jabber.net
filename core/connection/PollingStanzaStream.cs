using System;
using System.Diagnostics;
using System.Threading;
using System.Xml;

using Kixeye.Jabber.Net;
using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol;
using System.Security.Cryptography;

namespace Kixeye.Jabber.Connection
{
    /// <summary>
    /// Manages the HTTP Polling XMPP stream.
    /// </summary>
    public class PollingStanzaStream : HttpStanzaStream
    {
        ///<summary>
        /// Creates a PollingStanzaStream
        ///</summary>
        ///<param name="listener">Listener associated with PollingStanzaStream.</param>
        public PollingStanzaStream(IStanzaEventListener listener) : base(listener)
        {
        }

        /// <summary>
        /// Create a XEP25Socket.
        /// </summary>
        /// <returns></returns>
        protected override BaseSocket CreateSocket()
        {
            return new XEP25Socket(this);
        }
    }
}

