using System;

using Kixeye.Bedrock.Util;

using Kixeye.Jabber.Connection;
using Kixeye.Jabber.Connection.SASL;
using Kixeye.Jabber.Protocol.Stream;

using NUnit.Framework;
using System.Xml;

namespace test.kixeye.jabber.connection.sasl
{
    [TestFixture]
    public class MD5ProcessorTest
    {
        [Test]
        public void TestChallenge()
        {

            XmlDocument doc = new XmlDocument();
            Challenge c = new Challenge(doc);
            c.InnerText = "cmVhbG09IndlYjIwMDMiLCBub25jZT0iWWE0anVNYzU0SG9UWDBPa1VPRDFvQT09IiwgcW9wPSJhdXRoLCBhdXRoLWludCIsIGNoYXJzZXQ9dXRmLTgsIGFsZ29yaXRobT1tZDUtc2Vzcw==";

            MD5Processor m = new MD5Processor();
            m["username"] = "test";
            m["password"] = "test";
            Step s = m.step(c, doc);
            Assert.IsNotNull(s);
            Assert.AreEqual("Ya4juMc54HoTX0OkUOD1oA==", m["nonce"]);
            Assert.AreEqual("auth, auth-int", m["qop"]);
        }
    }
}
