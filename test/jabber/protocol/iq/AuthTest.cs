using System;

using System.Xml;
using NUnit.Framework;

using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol;
using Kixeye.Jabber.Protocol.Client;
using Kixeye.Jabber.Protocol.IQ;

namespace test.kixeye.jabber.protocol.iq
{
    /// <summary>
    /// Summary description for AuthTest.
    /// </summary>
    [TestFixture]
    public class AuthTest
    {
        XmlDocument doc = new XmlDocument();
        [SetUp]
        public void SetUp()
        {
            Element.ResetID();
        }
        [Test] public void Test_Create()
        {
            IQ iq = new AuthIQ(doc);
            Assert.AreEqual("<iq id=\""+iq.ID+"\" type=\"get\"><query xmlns=\"jabber:iq:auth\" /></iq>", iq.ToString());
        }
        [Test] public void Test_Hash()
        {
            IQ iq = new AuthIQ(doc);
            iq.Type = IQType.set;
            Auth a = (Auth) iq.Query;
            a.SetDigest("foo", "bar", "3B513636");
            a.Resource = "Home";
            Assert.AreEqual("<iq id=\""+iq.ID+"\" type=\"set\"><query xmlns=\"jabber:iq:auth\">" +
                "<username>foo</username>" +
                "<digest>37d9c887967a35d53b81f07916a309a5b8d7e8cc</digest>" +
                "<resource>Home</resource>" +
                "</query></iq>",
                iq.ToString());
        }
        /*
        SENT: <iq type="get" id="JCOM_14"><query xmlns="jabber:iq:auth"><username>zeroktest</username></query></iq>
        RECV: <iq id='JCOM_14' type='result'><query xmlns='jabber:iq:auth'><username>zeroktest</username><password/><digest/><sequence>499</sequence><token>3C7A6B0A</token><resource/></query></iq>
        SENT: <iq type="set" id="JCOM_15"><query xmlns="jabber:iq:auth"><username>zeroktest</username><hash>e00c83748492a3bc7e4831c9e973d117082c3abe</hash><resource>Winjab</resource></query></iq>
        */
        [Test] public void Test_ZeroK()
        {
            IQ iq = new AuthIQ(doc);
            iq.Type = IQType.set;
            Auth a = (Auth) iq.Query;
            a.SetZeroK("zeroktest", "test", "3C7A6B0A", 499);
            a.Resource = "Winjab";
            Assert.AreEqual("<iq id=\""+iq.ID+"\" type=\"set\"><query xmlns=\"jabber:iq:auth\">" +
                "<username>zeroktest</username>" +
                "<hash>e00c83748492a3bc7e4831c9e973d117082c3abe</hash>" +
                "<resource>Winjab</resource>" +
                "</query></iq>",
                iq.ToString());
        }
    }
}
