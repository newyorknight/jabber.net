using System;

using System.Xml;
using NUnit.Framework;

using Kixeye.Bedrock.Util;
using Kixeye.Jabber;
using Kixeye.Jabber.Protocol;
using Kixeye.Jabber.Protocol.IQ;

namespace test.kixeye.jabber.protocol.iq
{
    /// <summary>
    /// Summary description for RosterTest.
    /// </summary>
    [TestFixture]
    public class RegisterTest
    {
        XmlDocument doc = new XmlDocument();
        [SetUp]
        public void SetUp()
        {
            Element.ResetID();
        }
        [Test] public void Test_Create()
        {
            Register r = new Register(doc);
            Assert.AreEqual("<query xmlns=\"jabber:iq:register\" />", r.ToString());
        }
        [Test] public void Test_Registered()
        {
            Register r = new Register(doc);
            r.Registered = true;
            Assert.AreEqual("<query xmlns=\"jabber:iq:register\"><registered /></query>", r.ToString());
            Assert.IsTrue(r.Registered);
        }
    }
}
