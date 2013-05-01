using System;

using System.Xml;

using Kixeye.Bedrock.Util;

namespace Kixeye.Jabber.Protocol.Accept
{
    /// <summary>
    /// The type field in a log tag.
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// None specified
        /// </summary>
        NONE = -1,
        /// <summary>
        /// type='warn'
        /// </summary>
        warn,
        /// <summary>
        /// type='info'
        /// </summary>
        info,
        /// <summary>
        /// type='verbose'
        /// </summary>
        verbose,
        /// <summary>
        /// type='debug'
        /// </summary>
        debug
    }

    /// <summary>
    /// The log packet.
    /// </summary>
    public class Log : Kixeye.Jabber.Protocol.Packet
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public Log(XmlDocument doc) : base("log", doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Log(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// The element inside the route tag.
        /// </summary>
        public XmlElement Element
        {
            get { return this["element"]; }
            set { AddChild(value); }
        }

        /// <summary>
        /// The type attribute
        /// </summary>
        public LogType Type
        {
            get { return GetEnumAttr<LogType>("type"); }
            set { SetEnumAttr("type", value); }
        }

        /// <summary>
        /// The namespace for logging
        /// </summary>
        public string NS
        {
            get { return GetAttribute("ns"); }
            set { SetAttribute("ns", value); }
        }

        /// <summary>
        /// The server thread this came from
        /// </summary>
        public string Thread
        {
            get { return GetAttribute("thread"); }
            set { SetAttribute("thread", value); }
        }

        /// <summary>
        /// Time sent.
        /// </summary>
        public DateTime Timestamp
        {
            get { return JabberDate(GetAttribute("timestamp")); }
            set { SetAttribute("timestamp", JabberDate(value)); }
        }

    }
}