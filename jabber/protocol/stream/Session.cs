using System;
using System.Xml;

using bedrock.util;

namespace jabber.protocol.stream
{
    /// <summary>
    /// Session start after binding
    /// </summary>
    public class Session : Element
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public Session(XmlDocument doc) :
            base("", new XmlQualifiedName("session", jabber.protocol.URI.SESSION), doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Session(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }
    }
}
