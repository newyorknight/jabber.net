using System;

using System.Xml;

using Kixeye.Bedrock.Util;

namespace Kixeye.Jabber.Protocol.Accept
{
    /// <summary>
    /// The type field in a route tag.
    /// </summary>
    public enum RouteType
    {
        /// <summary>
        /// None specified
        /// </summary>
        NONE = -1,
        /// <summary>
        /// type='error'
        /// </summary>
        error,
        /// <summary>
        /// type='auth'
        /// </summary>
        auth,
        /// <summary>
        /// type='session'
        /// </summary>
        session
    }

    /// <summary>
    /// The route packet.
    /// </summary>
    public class Route : Kixeye.Jabber.Protocol.Packet
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public Route(XmlDocument doc) : base("route", doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Route(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// The element inside the route tag.
        /// </summary>
        public XmlElement Contents
        {
            get { return (XmlElement) this.FirstChild; }
            set
            {
                this.InnerXml = "";
                AddChild(value);
            }
        }

        /// <summary>
        /// The type attribute
        /// </summary>
        public RouteType Type
        {
            get { return GetEnumAttr<RouteType>("type"); }
            set { SetEnumAttr("type", value); }
        }
    }
}
