using System;
using System.Xml;

using Kixeye.Bedrock.Util;

namespace Kixeye.Jabber.Protocol.Stream
{
    /// <summary>
    /// Start-TLS in stream features.
    /// </summary>
    public class StartTLS : Element
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public StartTLS(XmlDocument doc) :
            base("", new XmlQualifiedName("starttls", Kixeye.Jabber.Protocol.URI.START_TLS), doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public StartTLS(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// Is starttls required?
        /// </summary>
        public bool Required
        {
            get { return this["required"] != null; }
            set
            {
                if (value)
                {
                    if (this["required"] == null)
                    {
                        SetElem("required", null);
                    }
                }
                else
                {
                    if (this["required"] != null)
                    {
                        RemoveElem("required");
                    }
                }
            }
        }
    }

    /// <summary>
    /// Start-TLS proceed.
    /// </summary>
    public class Proceed : Element
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public Proceed(XmlDocument doc) :
            base("", new XmlQualifiedName("proceed", Kixeye.Jabber.Protocol.URI.START_TLS), doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Proceed(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }
    }

    /// <summary>
    /// Start-TLS failure.
    /// </summary>
    public class TLSFailure : Element
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="xmlns"></param>
        public TLSFailure(XmlDocument doc, string xmlns) :
            base("", new XmlQualifiedName("failure", Kixeye.Jabber.Protocol.URI.START_TLS), doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public TLSFailure(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }
    }
}
