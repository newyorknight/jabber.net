using System;

using System.Xml;

using bedrock.util;

namespace jabber.protocol.stream
{
    /// <summary>
    /// Stream error packet.
    /// </summary>
    public class Error : Element
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public Error(XmlDocument doc) : base("stream", new XmlQualifiedName("error", URI.STREAM), doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Error(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// The error message
        /// </summary>
        public string Message
        {
            get { return this.InnerText; }
            set { this.InnerXml = value; }
        }
    }
}
