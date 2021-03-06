using System;

namespace Kixeye.Bedrock
{
    /// <summary>
    /// Delegate for memebers that just have a sender
    /// </summary>
    public delegate void ObjectHandler(object sender);

    /// <summary>
    /// Delegate for members that receive a string
    /// </summary>
    public delegate void TextHandler(object sender, string txt);

    /// <summary>
    /// Delegate for methods that get a block of bytes
    /// </summary>
    public delegate void ByteHandler(object sender, byte[] buf);

    /// <summary>
    /// Delegate for members that receive partial blocks of bytes.
    /// </summary>
    public delegate void ByteOffsetHandler(object sender, byte[] buf, int offset, int length);

    /// <summary>
    /// Delegate for members that receive an exception
    /// </summary>
    public delegate void ExceptionHandler(object sender, Exception ex);
}
