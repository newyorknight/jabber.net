using System;

using System.Xml;
using NUnit.Framework;

using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol;
using Kixeye.Jabber.Protocol.X;

namespace test.kixeye.jabber.protocol.x
{
    /// <summary>
    /// Summary description for AuthTest.
    /// </summary>
    [TestFixture]
    public class EventTest
    {
        XmlDocument doc = new XmlDocument();
        [SetUp]
        public void SetUp()
        {
            Element.ResetID();
        }
        [Test] public void Test_Create()
        {
            Event e = new Event(doc);
            Assert.AreEqual("<x xmlns=\"jabber:x:event\" />", e.ToString());
            e.ID = "foo";
            Assert.AreEqual("<x xmlns=\"jabber:x:event\"><id>foo</id></x>", e.ToString());
            Assert.AreEqual("foo", e.ID);
            Assert.AreEqual(EventType.NONE, e.Type);
            e.Type = EventType.composing;
            Assert.AreEqual(EventType.composing, e.Type);
            e.Type = EventType.delivered;
            Assert.AreEqual(EventType.delivered, e.Type);
            Assert.AreEqual("<x xmlns=\"jabber:x:event\"><id>foo</id><delivered /></x>", e.ToString());
            Assert.AreEqual(true, e.IsDelivered);
            Assert.AreEqual(false, e.IsComposing);
            e.IsComposing = true;
            Assert.AreEqual("<x xmlns=\"jabber:x:event\"><id>foo</id><delivered /><composing /></x>", e.ToString());
            Assert.AreEqual(EventType.composing | EventType.delivered, e.Type);
        }
    }
}
