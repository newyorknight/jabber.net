using System;

using System.Xml;

using Kixeye.Bedrock.Util;

namespace Kixeye.Jabber.Protocol.IQ
{
    /*
     *  <iq id='l4' type='result' from='user@host'>
     *    <query xmlns='jabber:iq:last' seconds='903'>
     *      Heading home
     *    </query>
     *  </iq>
     */
    /// <summary>
    /// IQ packet with an Last query element inside.
    /// </summary>
    public class LastIQ : Kixeye.Jabber.Protocol.Client.TypedIQ<Last>
    {
        /// <summary>
        /// Create a Last IQ
        /// </summary>
        /// <param name="doc"></param>
        public LastIQ(XmlDocument doc) : base(doc)
        {
        }
    }

    /// <summary>
    /// A Last query element, which requests the last activity from an entity.
    /// </summary>
    public class Last : Element
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public Last(XmlDocument doc) : base("query", URI.LAST, doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Last(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// The message inside the Last element.
        /// </summary>
        public string Message
        {
            get { return this.InnerText; }
            set { this.InnerText = value; }
        }

        /// <summary>
        /// How many seconds since the last activity.
        /// </summary>
        public int Seconds
        {
            get { return GetIntAttr("seconds");}
            set { SetAttribute("seconds", value.ToString()); }
        }
    }
}
