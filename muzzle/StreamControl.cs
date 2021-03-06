using System;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Xml;

using Kixeye.Bedrock.Util;
using Kixeye.Jabber;
using Kixeye.Jabber.Connection;
using Kixeye.Jabber.Protocol.Client;

namespace muzzle
{
    /// <summary>
    /// A UserControl that references an XmppStream.
    /// </summary>
    public class StreamControl : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// The XmppStream for this control.  Set at design time when a subclass control is dragged onto a form.
        /// </summary>
        protected XmppStream m_stream = null;

        /// <summary>
        /// The XmppStream was changed.  Often at design time.  The object will be this StreamControl.
        /// </summary>
        public event Kixeye.Bedrock.ObjectHandler OnStreamChanged;

        /// <summary>
        /// The JabberClient or JabberService to hook up to.
        /// </summary>
        [Description("The JabberClient or JabberService to hook up to.")]
        [Category("Jabber")]
        public virtual XmppStream Stream
        {
            get
            {
                return m_stream;
            }
            set
            {
                if ((object)m_stream != (object)value)
                {
                    m_stream = value;
                    if (OnStreamChanged != null)
                        OnStreamChanged(this);
                }
            }
        }

        private JID m_overrideFrom = null;

        /// <summary>
        /// Override the from address that will be stamped on outbound packets.
        /// Unless your server implemets XEP-193, you shouldn't use this for 
        /// client connections.
        /// </summary>
        public JID OverrideFrom
        {
            get { return m_overrideFrom; }
            set { m_overrideFrom = value; }
        }

        /// <summary>
        /// Write the specified stanza to the stream.
        /// </summary>
        /// <param name="elem"></param>
        public void Write(XmlElement elem)
        {
            if ((m_overrideFrom != null) && (elem.GetAttribute("from") == ""))
                elem.SetAttribute("from", m_overrideFrom);
            m_stream.Write(elem);
        }

        ///<summary>
        /// Does an asynchronous IQ call.
        /// If the from address hasn't been set, and an OverrideFrom has been set,
        /// the from address will be set to the value of OverrideFrom.
        ///</summary>
        ///<param name="iq">IQ packet to send.</param>
        ///<param name="cb">Callback to execute when the result comes back.</param>
        ///<param name="cbArg">Arguments to pass to the callback.</param>
        public void BeginIQ(IQ iq, IqCB cb, object cbArg)
        {
            if ((m_overrideFrom != null) && (iq.From == null))
                iq.From = m_overrideFrom;
            m_stream.Tracker.BeginIQ(iq, cb, cbArg);
        }
    }
}
