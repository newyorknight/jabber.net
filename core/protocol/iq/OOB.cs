using System;

using System.Xml;

using Kixeye.Bedrock.Util;

namespace Kixeye.Jabber.Protocol.IQ
{
    /*
     * <iq type="set" to="horatio@denmark" from="sailor@sea" id="i_oob_001">
     *   <query xmlns="jabber:iq:oob">
     *     <url>http://denmark/act4/letter-1.html</url>
     *     <desc>There's a letter for you sir.</desc>
     *   </query>
     * </iq>
     */
    /// <summary>
    /// IQ packet with an oob query element inside.
    /// </summary>
    public class OobIQ : Kixeye.Jabber.Protocol.Client.TypedIQ<OOB>
    {
        /// <summary>
        /// Create an OOB IQ.
        /// </summary>
        /// <param name="doc"></param>
        public OobIQ(XmlDocument doc) : base(doc)
        {
        }
    }

    /// <summary>
    /// An oob query element for file transfer.
    /// </summary>
    public class OOB : Element
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public OOB(XmlDocument doc) : base("query", URI.OOB, doc)
        {
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public OOB(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// URL to send/receive from
        /// </summary>
        public string Url
        {
            get { return GetElem("url"); }
            set { SetElem("url", value); }
        }

        /// <summary>
        /// File description
        /// </summary>
        public string Desc
        {
            get { return GetElem("desc"); }
            set { SetElem("desc", value); }
        }
    }
}
