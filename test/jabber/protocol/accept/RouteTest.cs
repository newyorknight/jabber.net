using System;

using System.Xml;
using NUnit.Framework;

using bedrock.util;
using jabber.protocol.accept;

namespace test.jabber.protocol.accept
{
    /// <summary>
    /// Summary description for IQTest.
    /// </summary>
    [TestFixture]
    public class RouteTest
    {
        XmlDocument doc = new XmlDocument();
        [Test] public void Test_Create()
        {
            Route r = new Route(doc);
            r.Contents = doc.CreateElement("foo");
            Assert.AreEqual("<route><foo /></route>", r.OuterXml);
            XmlElement foo = r.Contents;
            Assert.AreEqual("<foo />", foo.OuterXml);
        }
    }
}
