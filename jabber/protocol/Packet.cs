using System;

using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Xml;

using bedrock.util;

namespace jabber.protocol
{
    /// <summary>
    /// Packets that have to/from information.
    /// </summary>
    public class Packet : Element
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Packet(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="localName"></param>
        /// <param name="doc"></param>
        public Packet(string localName, XmlDocument doc) :
            base(localName, URI.CLIENT, doc)
        {
        }

        /// <summary>
        /// The TO address
        /// </summary>
        public JID To
        {
            get { return (JID)this.GetAttr("to"); }
            set { SetAttr("to", value); }
        }

        /// <summary>
        ///  The FROM address
        /// </summary>
        public JID From
        {
            get { return (JID)this.GetAttr("from"); }
            set { SetAttr("from", value); }
        }

        /// <summary>
        /// The packet ID.
        /// </summary>
        public string ID
        {
            get { return this.GetAttr("id"); }
            set { this.SetAttr("id", value); }
        }

        /// <summary>
        /// Swap the To and the From addresses.
        /// </summary>
        public virtual void Swap()
        {
            string tmp = this.GetAttribute("to");
            this.SetAttribute("to", this.GetAttribute("from"));
            this.SetAttribute("from", tmp);
        }
    }
}
