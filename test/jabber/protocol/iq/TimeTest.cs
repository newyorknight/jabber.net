using System;

using System.Xml;
using NUnit.Framework;

using Kixeye.Bedrock.Util;
using Kixeye.Jabber;
using Kixeye.Jabber.Protocol;
using Kixeye.Jabber.Protocol.Client;
using Kixeye.Jabber.Protocol.IQ;

namespace test.kixeye.jabber.protocol.iq
{
    [TestFixture]
    public class TimeTest
    {
        [Test]
        public void UTC()
        {
            XmlDocument doc = new XmlDocument();
            TimeIQ iq = new TimeIQ(doc);
            Time t = iq.Instruction;
            t.AddChild(doc.CreateElement("utc", t.NamespaceURI));
            Assert.AreEqual(DateTime.MinValue, t.UTC);
            DateTime start = DateTime.UtcNow;
            t.SetCurrentTime();

            // SetCurrentTime only stores seconds portion, whereas UtcNow has all 
            // kinds of precision.  Are we within a second of being correct?
            TimeSpan ts = t.UTC - start;
            Assert.IsTrue(Math.Abs(ts.TotalSeconds) < 1.0);
        }
    }
}
