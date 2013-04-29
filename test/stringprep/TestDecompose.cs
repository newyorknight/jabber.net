#if !NO_STRINGPREP

using System;
using NUnit.Framework;
using stringprep.unicode;

namespace test.stringprep
{
    /// <summary>
    /// Summary description for TestGeneric.
    /// </summary>
    [TestFixture]
    public class TestDecompose
    {
        public void Test_Decomp()
        {
            char[] d = Decompose.Find('\x2000');
            Assertion.AssertNotNull(d);
            Assertion.AssertEquals(1, d.Length);
            Assertion.AssertEquals('\x0020', d[0]);
        }
    }
}
#endif
