using System;

using NUnit.Framework;
using Kixeye.Bedrock.IO;
using Kixeye.Bedrock.Util;
using System.Xml;

using Kixeye.Jabber.Connection;
using Kixeye.Jabber.Protocol;
using Kixeye.Jabber.Protocol.IQ;

namespace test.kixeye.jabber.connection
{
    [TestFixture]
    public class FileMapTest
    {
        XmlDocument doc = new XmlDocument();

        DiscoInfo Element
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                global::Kixeye.Jabber.Protocol.IQ.DiscoInfo di = new global::Kixeye.Jabber.Protocol.IQ.DiscoInfo(doc);
                di.AddFeature(global::Kixeye.Jabber.Protocol.URI.DISCO_INFO);
                di.AddFeature(global::Kixeye.Jabber.Protocol.URI.DISCO_ITEMS);
                return di;
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNull()
        {
            FileMap<Element> fm = new FileMap<Element>("test.xml", null);
            Assert.IsNotNull(fm);
            FileMap<DiscoInfo> fm2 = new FileMap<DiscoInfo>("test.xml", null);
        }

        [Test]
        public void TestCreate()
        {
            ElementFactory ef = new ElementFactory();
            ef.AddType(new global::Kixeye.Jabber.Protocol.IQ.Factory());

            string g = new Guid().ToString();
            FileMap<DiscoInfo> fm = new FileMap<DiscoInfo>("test.xml", ef);
            fm.Clear();
            Assert.AreEqual(0, fm.Count);

            fm[g] = Element;
            Assert.IsTrue(fm.Contains(g));
            Assert.IsFalse(fm.Contains("foo"));
            Assert.IsInstanceOfType(typeof(DiscoInfo), fm[g]);
            Assert.AreEqual(1, fm.Count);

            // re-read, to reparse
            fm = new FileMap<DiscoInfo>("test.xml", ef);
            Assert.IsTrue(fm.Contains(g));
            Assert.IsInstanceOfType(typeof(DiscoInfo), fm[g]);

            fm[g] = null;
            Assert.AreEqual(1, fm.Count);

            fm.Remove(g);
            Assert.AreEqual(0, fm.Count);
        }
    }
}
