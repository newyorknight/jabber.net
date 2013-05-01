using System;

using System.Xml;
using NUnit.Framework;

using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol;
using Kixeye.Jabber.Protocol.Client;
using Kixeye.Jabber.Protocol.IQ;

namespace test.kixeye.jabber.protocol.client
{
    /// <summary>
    /// Summary description for IQTest.
    /// </summary>
    [TestFixture]
    public class IQTest
    {
        XmlDocument doc = new XmlDocument();

        [Test]
        public void Create()
        {
            Element.ResetID();

            IQ iq = new IQ(doc);
            Assert.AreEqual("<iq id=\"JN_1\" type=\"get\" />", iq.ToString());
            iq = new IQ(doc);
            Assert.AreEqual("<iq id=\"JN_2\" type=\"get\" />", iq.ToString());
            iq.Query = new Auth(doc);
            Assert.AreEqual("<iq id=\"JN_2\" type=\"get\"><query xmlns=\"jabber:iq:auth\" /></iq>", iq.ToString());
        }
    }
}
