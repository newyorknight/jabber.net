using System;
using System.Xml;
using Kixeye.Bedrock.Util;

namespace Kixeye.Jabber.Protocol.Stream
{
    /// <summary>
    /// Stream Features handler
    /// </summary>
    public delegate void FeaturesHandler(Object sender, Features feat);

    /// <summary>
    /// Stream features.  Will only be set by a version="1.0" or higher XMPP server.
    /// </summary>
    public class Features : Element
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public Features(XmlDocument doc) :
            base("stream", new XmlQualifiedName("features", Kixeye.Jabber.Protocol.URI.STREAM), doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Features(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// The starttls element, or null if none found.
        /// </summary>
        public StartTLS StartTLS
        {
            get { return this["starttls", Kixeye.Jabber.Protocol.URI.START_TLS] as StartTLS; }
            set { ReplaceChild(value); }
        }

        /// <summary>
        /// The SASL mechanisms, or null if none found.
        /// </summary>
        public Mechanisms Mechanisms
        {
            get { return this["mechanisms", Kixeye.Jabber.Protocol.URI.SASL] as Mechanisms; }
            set { ReplaceChild(value); }
        }

        /// <summary>
        /// The compression element, or null if none found.
        /// </summary>
        public Compression Compression
        {
            get { return this["compression", Kixeye.Jabber.Protocol.URI.COMPRESS_FEATURE] as Compression; }
        }
    }
}
