namespace Kixeye.Xpnet
{
    using Kixeye.Bedrock.Util;

    /**
     * Represents a position in an entity.
     * A position can be modified by <code>Encoding.movePosition</code>.
     * @see Encoding#movePosition
     * @version $Revision$ $Date$
     */
    ///<summary>
    /// Position of an entry in a table.
    ///</summary>
    public class Position : System.ICloneable
    {
        private int lineNumber;
        private int columnNumber;

        /**
         * Creates a position for the start of an entity: the line number is
         * 1 and the column number is 0.
         */
        public Position()
        {
            lineNumber = 1;
            columnNumber = 0;
        }

        /**
         * Returns the line number.
         * The first line number is 1.
         */
        public int LineNumber
        {
            get {return lineNumber;}
            set {lineNumber = value;}
        }

        /**
         * Returns the column number.
         * The first column number is 0.
         * A tab character is not treated specially.
         */
        public int ColumnNumber
        {
            get { return columnNumber; }
            set { columnNumber = value; }
        }

        /**
         * Returns a copy of this position.
         */
        public object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}
