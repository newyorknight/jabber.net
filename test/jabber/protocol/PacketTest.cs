using System;

using System.Xml;
using NUnit.Framework;

using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol;

namespace test.kixeye.jabber.protocol
{
    /// <summary>
    /// Summary description for PacketTest.
    /// </summary>
    [TestFixture]
    public class PacketTest
    {
        XmlDocument doc = new XmlDocument();

        [Test] public void Test_Create()
        {
            Packet p = new Packet("foo", doc);
            Assert.AreEqual("<foo />", p.ToString());
            p.To = "one";
            Assert.AreEqual("<foo to=\"one\" />", p.ToString());
            p.From = "two";
            Assert.AreEqual("<foo to=\"one\" from=\"two\" />", p.ToString());
            p.Swap();
            Assert.AreEqual("<foo to=\"two\" from=\"one\" />", p.ToString());
        }

        [Test] public void Test_JabberDate()
        {
            string sdt = "20020504T20:39:42";
            DateTime dt = Element.JabberDate(sdt);
            Assert.AreEqual(2002, dt.Year);
            Assert.AreEqual(5, dt.Month);
            Assert.AreEqual(4, dt.Day);
            Assert.AreEqual(20, dt.Hour);
            Assert.AreEqual(39, dt.Minute);
            Assert.AreEqual(42, dt.Second);
            Assert.AreEqual(sdt, Element.JabberDate(dt));
        }
        [Test] public void Test_DateTimeProfile()
        {
            string sdt = "2002-05-04T20:39:42.050Z";
            DateTime dt = Element.DateTimeProfile(sdt);
            Assert.AreEqual(2002, dt.Year);
            Assert.AreEqual(5, dt.Month);
            Assert.AreEqual(4, dt.Day);
            Assert.AreEqual(20, dt.Hour);
            Assert.AreEqual(39, dt.Minute);
            Assert.AreEqual(42, dt.Second);
            Assert.AreEqual(sdt, Element.DateTimeProfile(dt));
        }
    }
}
