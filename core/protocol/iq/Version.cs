using System;

using System.Xml;

using Kixeye.Bedrock.Util;

namespace Kixeye.Jabber.Protocol.IQ
{
    /// <summary>
    /// IQ packet with a version query element inside.
    /// </summary>
    public class VersionIQ : Kixeye.Jabber.Protocol.Client.TypedIQ<Version>
    {
        /// <summary>
        /// Create a version IQ
        /// </summary>
        /// <param name="doc"></param>
        public VersionIQ(XmlDocument doc) : base(doc)
        {
        }
    }

    /// <summary>
    /// A time query element.
    /// </summary>
    public class Version : Element
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public Version(XmlDocument doc) : base("query", URI.VERSION, doc)
        {
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Version(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// Name of the entity.
        /// </summary>
        public string EntityName
        {
            get { return GetElem("name"); }
            set { SetElem("name", value); }
        }

        /// <summary>
        /// Enitity version.  (Version was a keyword, or something)
        /// </summary>
        public string Ver
        {
            get { return GetElem("version"); }
            set { SetElem("version", value); }
        }

        /// <summary>
        /// Operating system of the entity.
        /// </summary>
        public string OS
        {
            get { return GetElem("os"); }
            set { SetElem("os", value); }
        }
    }
}
