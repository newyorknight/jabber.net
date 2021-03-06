#if !NO_STRINGPREP

using System;
using NUnit.Framework;
using Kixeye.Bedrock.StringPrep;
using Kixeye.Bedrock.StringPrep.Steps;
using Kixeye.Bedrock.Util;

namespace test.stringprep
{
    [TestFixture]
    public class TestResourceprep
    {
        private static System.Text.Encoding ENC = System.Text.Encoding.UTF8;

        private Profile resourceprep = new XmppResource();

        private void TryOne(string input, string expected)
        {
            string output = resourceprep.Prepare(input);
            Assert.AreEqual(expected, output);
        }

        [Test] public void Test_Good()
        {
            TryOne("Test", "Test");
            TryOne("test", "test");
        }

        [ExpectedException(typeof(ProhibitedCharacterException))]
        [Test] public void Test_Bad()
        {
            TryOne("Test\x180E", null);
        }
    }
}
#endif
