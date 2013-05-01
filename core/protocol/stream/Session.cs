using System;
using System.Xml;

using Kixeye.Bedrock.Util;

namespace Kixeye.Jabber.Protocol.Stream
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
            base("", new XmlQualifiedName("session", Kixeye.Jabber.Protocol.URI.SESSION), doc)
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
