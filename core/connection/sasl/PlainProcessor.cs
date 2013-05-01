using System;
using System.IO;
using System.Diagnostics;
using System.Xml;

using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol.Stream;

namespace Kixeye.Jabber.Connection.SASL
{
    /// <summary>
    /// SASL Mechanism PLAIN as specified in RFC 2595.
    /// </summary>
    public class PlainProcessor : SASLProcessor
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
            a.Mechanism = MechanismType.PLAIN;
            MemoryStream ms = new MemoryStream();

            // message = [authorize-id] NUL authenticate-id NUL password

            // Skip authzid.
            ms.WriteByte(0);
            string u = this[USERNAME];
            if ((u == null) || (u == ""))
                throw new SASLException("Username required");
            byte[] bu = System.Text.Encoding.UTF8.GetBytes(u);
            ms.Write(bu, 0, bu.Length);
            ms.WriteByte(0);
            string p = this[PASSWORD];
            if ((p == null) || (p == ""))
                throw new SASLException("Password required");
            byte[] pu = System.Text.Encoding.UTF8.GetBytes(p);
            ms.Write(pu, 0, pu.Length);

            a.Bytes = ms.ToArray();
            return a;
        }
    }
}
