using System.Xml;
using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol.IQ;
using NUnit.Framework;

namespace test.kixeye.jabber.protocol.iq
{
    [TestFixture]
    public class PubSubTest
    {
        private const string NODE = "TestNode";

        private XmlDocument doc;

        [SetUp]
        public void Setup()
        {
            doc = new XmlDocument();
        }

        [Test]
        public void AffiliationsTest()
        {
            PubSubIQ iq = new PubSubIQ(doc, PubSubCommandType.affiliations, NODE);
            Affiliations test = iq.Command as Affiliations;
            Assert.IsNotNull(test);
        }

        [Test]
        public void PubSubCreateTest()
        {
            PubSubIQ iq = new PubSubIQ(doc, PubSubCommandType.create, NODE);
            Assert.IsFalse(((Create)iq.Command).HasConfigure);

            Create create = (Create)iq.Command;

            create.HasConfigure = true;
            Assert.IsTrue(create.HasConfigure);
            Assert.IsNotNull(create.GetConfiguration());
        }

    }
}
