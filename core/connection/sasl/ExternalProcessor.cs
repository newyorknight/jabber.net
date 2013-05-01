using System;
using System.IO;
using System.Diagnostics;
using System.Xml;

using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol.Stream;

namespace Kixeye.Jabber.Connection.SASL
{
    /// <summary>
    /// SASL Mechanism EXTERNAL as specified in XEP-0178.
    /// </summary>
    public class ExternalProcessor : SASLProcessor
    {
        /// <summary>
        /// Perform the next step
        /// </summary>
        /// <param name="s">Null if it's the initial response</param>
        /// <param name="doc">Document to create Steps in</param>
        /// <returns></returns>
        public override Step step(Step s, XmlDocument doc)
        {
            Debug.Assert(s == null);
            Auth a = new Auth(doc);
            a.Mechanism = MechanismType.EXTERNAL;
            return a;
        }
    }
}
