using System;
using Kixeye.Bedrock.Util;

namespace Kixeye.Jabber.Net
{
    /// <summary>
    /// Lame exception, since I couldn't find one I liked.
    /// </summary>
    [Serializable]
    public class AsyncSocketConnectionException : System.SystemException
    {
        /// <summary>
        /// Create a new exception instance.
        /// </summary>
        /// <param name="description"></param>
        public AsyncSocketConnectionException(string description)
            : base(description)
        {
        }

        /// <summary>
        /// Create a new exception instance.
        /// </summary>
        public AsyncSocketConnectionException()
            : base()
        {
        }

        /// <summary>
        /// Create a new exception instance, wrapping another exception.
        /// </summary>
        /// <param name="description">Desecription of the exception</param>
        /// <param name="e">Inner exception</param>
        public AsyncSocketConnectionException(string description, Exception e)
            : base(description, e)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// AsyncSocketConnectionException class with serialized
        /// data.
        /// </summary>
        /// <param name="info">The object that holds the serialized
        /// object data.</param>
        /// <param name="ctx">The contextual information about the
        /// source or destination.</param>
        protected AsyncSocketConnectionException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext ctx)
            :
            base(info, ctx)
        {
        }
    }
}
