using System;

using NUnit.Framework;
using bedrock.collections;
using bedrock.util;
namespace test.bedrock.collections
{
    /// <summary>
    ///    Summary description for TemplateTest.
    /// </summary>
    [TestFixture]
    public class TrieNodeTest
    {
        [Test] public void Test_Main()
        {
            System.Text.Encoding ENC = System.Text.Encoding.Default;
            TrieNode n = new TrieNode(null, 0);
            byte[] key = ENC.GetBytes("test");
            TrieNode current = n;
            for (int i=0; i<key.Length; i++)
            {
                byte b = key[i];
                current = current[b, true];
            }
            current.Value = "foo";
            Assert.AreEqual(ENC.GetString(key), ENC.GetString(current.Key));
        }
    }
}
