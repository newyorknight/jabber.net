using System;

using System.Xml;
using NUnit.Framework;

using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol.Client;

namespace test.kixeye.jabber.protocol.client
{
    /// <summary>
    /// Summary description for PresenceTest.
    /// </summary>
    [TestFixture]
    public class PresenceTest
    {
        XmlDocument doc = new XmlDocument();
        [Test] public void Test_Create()
        {
            Presence p = new Presence(doc);
            p.Type   = PresenceType.available;
            p.Status = "foo";
            Assert.AreEqual("<presence><status>foo</status></presence>", p.ToString());
        }

        [Test] public void Test_Available()
        {
            Presence p = new Presence(doc);
            Assert.AreEqual(PresenceType.available, p.Type);
            Assert.AreEqual("", p.GetAttribute("type"));
            p.Type = PresenceType.unavailable;
            Assert.AreEqual(PresenceType.unavailable, p.Type);
            Assert.AreEqual("unavailable", p.GetAttribute("type"));
            p.Type = PresenceType.available;
            Assert.AreEqual(PresenceType.available, p.Type);
            Assert.AreEqual("", p.GetAttribute("type"));
        }

        [Test]
        public void Test_Order()
        {
            Presence small = new Presence(doc);
            DateTime d = DateTime.Now;
            small.IntPriority = 0;
            small.Stamp = d;

            Presence big = new Presence(doc);
            big.IntPriority = 10;
            big.Stamp = d.AddSeconds(1);

            Assert.IsTrue(small < big);
            Assert.IsTrue(big > small);

            small.IntPriority = 10;
            small.Show = "dnd";
            Assert.IsTrue(small < big);

            big.Show = "chat";
            Assert.IsTrue(small < big);

            small.Show = "chat";
            Assert.IsTrue(small < big);
        }
    }
}
