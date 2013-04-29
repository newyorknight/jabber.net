using System;

using NUnit.Framework;

using bedrock.util;
using jabber.protocol;
using fact = jabber.protocol.stream.Factory;

namespace test.jabber.protocol.stream
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
