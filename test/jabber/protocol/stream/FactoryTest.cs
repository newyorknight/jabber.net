using System;

using NUnit.Framework;

using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol;
using fact = Kixeye.Jabber.Protocol.Stream.Factory;

namespace test.kixeye.jabber.protocol.stream
{
    /// <summary>
    /// Summary description for StreamFactoryTest.
    /// </summary>
    [TestFixture]
    public class StreamFactoryTest
    {
        [Test] public void Test_Create()
        {
            ElementFactory pf = new ElementFactory();
            pf.AddType(new fact());
        }
    }
}
