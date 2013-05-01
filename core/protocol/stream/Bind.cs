using System;
using System.Xml;

using Kixeye.Bedrock.Util;

namespace Kixeye.Jabber.Protocol.Stream
{
    /// <summary>
    /// Bind start after binding
    /// </summary>
    public class Bind : Element
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public Bind(XmlDocument doc) :
            base("", new XmlQualifiedName("bind", Kixeye.Jabber.Protocol.URI.BIND), doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Bind(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// The resource to bind to.  Null says for the server to pick.
        /// </summary>
        public string Resource
        {
            get { return GetElem("resource"); }
            set { SetElem("resource", value); }
        }

        /// <summary>
        /// The JID that the server selected for us.
        /// </summary>
        public string JID
        {
            get { return GetElem("jid"); }
            set { SetElem("jid", value); }
        }
    }
}
