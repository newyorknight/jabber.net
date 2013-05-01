using System;
using System.Xml;

using Kixeye.Bedrock.Util;


namespace Kixeye.Jabber.Protocol.X
{
    /// <summary>
    /// Entity Capabilities.  See http://www.xmpp.org/extensions/xep-0115.html.
    /// </summary>
    public class Caps : Element
    {
        private static readonly char[] SPLIT = " ".ToCharArray();

        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public Caps(XmlDocument doc)
            : base("c", URI.CAPS, doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Caps(string prefix, XmlQualifiedName qname, XmlDocument doc)
            : base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// The URI that describes the entity.
        /// </summary>
        public string Node
        {
            get { return GetAttr("node"); }
            set { SetAttr("node", value); }
        }

        /// <summary>
        /// The version of the entity.
        /// </summary>
        public string Version
        {
            get { return GetAttr("ver"); }
            set { SetAttr("ver", value); }
        }

        /// <summary>
        /// The hash type being used, or null for pre-v1.5 of XEP-115.
        /// </summary>
        public string Hash
        {
            get { return GetAttr("hash"); }
            set { SetAttr("hash", value); }
        }

        /// <summary>
        /// Is this a new-style (post v1.5) caps?
        /// </summary>
        public bool NewStyle
        {
            get { return HasAttribute("hash"); }
        }

        /// <summary>
        /// The extensions currently on in the entity.
        /// </summary>
        [Obsolete]
        public string[] Extensions
        {
            get { return GetAttr("ext").Split(SPLIT); }
            set
            {
                if (value.Length == 0)
                {
                    if (this.HasAttribute("ext"))
                        RemoveAttribute("ext");
                }
                else
                    SetAttr("ext", string.Join(" ", value));
            }
        }

        /// <summary>
        /// All of the combinations of node#ver, node#ext.
        /// </summary>
        [Obsolete]
        public string[] DiscoInfoNodes
        {
            get
            {
                string[] exts = Extensions;
                string[] nodes = new string[exts.Length + 1];
                int count = 0;
                nodes[count] = Node + "#" + Version;
                foreach (string ext in exts)
                {
                    nodes[++count] = Node + "#" + ext;
                }

                return nodes;
            }
        }
    }
}
