using System;

using System.Security.Cryptography;
using System.Xml;
using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol;

namespace Kixeye.Jabber.Protocol.Stream
{
    /// <summary>
    /// The fabled stream:stream packet.  Id's get assigned automatically on allocation.
    /// </summary>
    public class Stream : Packet
    {
        private static readonly RandomNumberGenerator RNG = RandomNumberGenerator.Create();

        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="xmlns"></param>
        public Stream(XmlDocument doc, string xmlns) :
            base("stream", new XmlQualifiedName("stream", Kixeye.Jabber.Protocol.URI.STREAM), doc)
        {
            byte[] buf = new byte[4];
            RNG.GetBytes(buf);
            ID = HexString(buf);
            NS = xmlns;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Stream(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// Default stream namespace.  xmlns=''.
        /// </summary>
        public string NS
        {
            get { return this.GetAttribute("xmlns"); }
            set { this.SetAttribute("xmlns", value); }
        }

        /// <summary>
        /// The version attribute.  "1.0" for an XMPP-core-compliant stream.
        /// </summary>
        public string Version
        {
            get { return this.GetAttribute("version"); }
            set { this.SetAttribute("version", value); }
        }

        /// <summary>
        /// Make sure that the namespace from this stream gets output.
        /// </summary>
        public override string OuterXml
        {
            get { return this.OriginalOuterXml; }
        }
    }
}
