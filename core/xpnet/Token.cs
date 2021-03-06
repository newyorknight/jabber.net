namespace Kixeye.Xpnet
{
    using Kixeye.Bedrock.Util;

    /// <summary>
    /// A token that was parsed.
    /// </summary>
    public class Token
    {
        private int tokenEnd = -1;
        private int nameEnd = -1;
        private char refChar1 = (char)0;
        private char refChar2 = (char)0;

        /// <summary>
        /// The end of the current token, in relation to the beginning of the buffer.
        /// </summary>
        public int TokenEnd
        {
            get {return tokenEnd;}
            set {tokenEnd = value; }
        }

        /// <summary>
        /// The end of the current token's name, in relation to the beginning of the buffer.
        /// </summary>
        public int NameEnd
        {
            get {return nameEnd;}
            set {nameEnd = value;}
        }

        /// <summary>
        /// The parsed-out character. &amp; for &amp;amp;
        /// </summary>
        public char RefChar1
        {
            get {return refChar1;}
            set {refChar1 = value; }
        }
        /// <summary>
        /// The second of two parsed-out characters.  TODO: find example.
        /// </summary>
        public char RefChar2
        {
            get {return refChar2;}
            set {refChar2 = value; }
        }

        /*
        public void getRefCharPair(char[] ch, int off) {
            ch[off] = refChar1;
            ch[off + 1] = refChar2;
        }
        */
    }
}
