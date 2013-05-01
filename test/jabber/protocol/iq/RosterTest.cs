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
    public class RosterTest
    {
        XmlDocument doc = new XmlDocument();
        [SetUp]
        public void SetUp()
        {
            Element.ResetID();
        }
        [Test] public void Test_Create()
        {
            Roster r = new Roster(doc);
            Assert.AreEqual("<query xmlns=\"jabber:iq:roster\" />", r.ToString());
        }

        [Test] public void Test_Item()
        {
            RosterIQ riq = new RosterIQ(doc);
            Roster r = riq.Instruction;
            Item i = r.AddItem();
            i.JID = new JID("hildjj@kixeye.jabber.com");
            Assert.AreEqual("<iq id=\""+riq.ID+"\" type=\"get\"><query xmlns=\"jabber:iq:roster\">" +
                "<item jid=\"hildjj@kixeye.jabber.com\" /></query></iq>",
                riq.ToString());
        }
        [Test] public void Test_GetItems()
        {
            RosterIQ riq = new RosterIQ(doc);
            Roster r = riq.Instruction;
            Item i = r.AddItem();
            i.JID = new JID("hildjj@kixeye.jabber.com");
            i = r.AddItem();
            i.Subscription = Subscription.from;
            i.JID = new JID("hildjj@kixeye.jabber.org");
            i.Subscription = Subscription.both;
            Item[] items = r.GetItems();
            Assert.AreEqual(items.Length, 2);
            Assert.AreEqual(items[0].JID, "hildjj@kixeye.jabber.com");
            Assert.AreEqual(items[1].JID, "hildjj@kixeye.jabber.org");
        }
        [Test] public void Test_Groups()
        {
            RosterIQ riq = new RosterIQ(doc);
            Roster r = riq.Instruction;
            Item i = r.AddItem();
            i.JID = new JID("hildjj@kixeye.jabber.com");
            Group g = i.AddGroup("foo");
            Assert.AreEqual("<iq id=\""+riq.ID+"\" type=\"get\"><query xmlns=\"jabber:iq:roster\">" +
                "<item jid=\"hildjj@kixeye.jabber.com\"><group>foo</group></item></query></iq>",
                riq.ToString());
            g = i.AddGroup("foo");
            Assert.AreEqual("<iq id=\""+riq.ID+"\" type=\"get\"><query xmlns=\"jabber:iq:roster\">" +
                "<item jid=\"hildjj@kixeye.jabber.com\"><group>foo</group></item></query></iq>",
                riq.ToString());
            g = i.AddGroup("bar");
            Assert.AreEqual("<iq id=\""+riq.ID+"\" type=\"get\"><query xmlns=\"jabber:iq:roster\">" +
                "<item jid=\"hildjj@kixeye.jabber.com\"><group>foo</group><group>bar</group></item></query></iq>",
                riq.ToString());
            Assert.AreEqual(2, i.GetGroups().Length);
            Assert.AreEqual("foo", i.GetGroup("foo").GroupName);
            Assert.AreEqual("bar", i.GetGroup("bar").GroupName);
            i.RemoveGroup("foo");
            Assert.AreEqual(1, i.GetGroups().Length);
            Assert.AreEqual(null, i.GetGroup("foo"));
        }
        [Test] public void Test_Ask()
        {
            RosterIQ riq = new RosterIQ(doc);
            Roster r = riq.Instruction;
            Item i = r.AddItem();
            Assert.AreEqual("", i.GetAttribute("ask"));
            Assert.AreEqual(Ask.NONE, i.Ask);
            i.Ask = Ask.subscribe;
            Assert.AreEqual("subscribe", i.GetAttribute("ask"));
            Assert.AreEqual(Ask.subscribe, i.Ask);
            i.Ask = Ask.NONE;
            Assert.AreEqual("", i.GetAttribute("ask"));
            Assert.AreEqual(Ask.NONE, i.Ask);
        }
    }
}
