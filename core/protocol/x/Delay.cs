using System;

using System.Xml;

using Kixeye.Bedrock.Util;

namespace Kixeye.Jabber.Protocol.X
{
    /// <summary>
    /// A delay x element.
    /// </summary>
    public class Delay : Element
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public Delay(XmlDocument doc) : base("x", URI.XDELAY, doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Delay(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// From whom?
        /// </summary>
        public string From
        {
            get { return GetAttribute("from"); }
            set { SetAttribute("from", value); }
        }

        /// <summary>
        /// Date/time stamp.
        /// </summary>
        public DateTime Stamp
        {
            get { return JabberDate(GetAttribute("stamp")); }
            set { SetAttribute("stamp", JabberDate(value)); }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Desc
        {
            get { return this.InnerText; }
            set { this.InnerText = value; }
        }
    }

    /// <summary>
    /// A modern, XEP-0203 delay element
    /// </summary>
    public class ModernDelay : Element
    {
/*
 <delay xmlns='urn:xmpp:delay'
     from='capulet.com'
     stamp='2002-09-10T23:08:25Z'>
    Offline Storage
  </delay>
*/
        /// <summary>
        ///Create a delay element for sending
        /// </summary>
        /// <param name="doc"></param>
        public ModernDelay(XmlDocument doc) : base("delay", URI.DELAY, doc)
        {
        }

        /// <summary>
        /// Create a delay element from the received stream.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public ModernDelay(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// From whom?
        /// </summary>
        public string From
        {
            get { return GetAttribute("from"); }
            set { SetAttribute("from", value); }
        }

        /// <summary>
        /// Date/time stamp.
        /// </summary>
        public DateTime Stamp
        {
            get { return Element.DateTimeProfile(GetAttribute("stamp")); }
            set { SetAttribute("stamp", Element.DateTimeProfile(value)); }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Desc
        {
            get { return this.InnerText; }
            set { this.InnerText = value; }
        } 
    }
}
