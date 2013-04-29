using System;


using bedrock.util;
using jabber.protocol;

namespace jabber.protocol.accept
{
    /// <summary>
    /// A packet factory for the jabber:component:accept namespace.
    /// </summary>
    public class Factory : IPacketTypes
    {
        private static QnameType[] s_qnt = new QnameType[]
        {
            new QnameType("handshake", URI.ACCEPT, typeof(Handshake)),
            new QnameType("route",     URI.ACCEPT, typeof(Route)),
            new QnameType("xdb",       URI.ACCEPT, typeof(Xdb)),
            new QnameType("log",       URI.ACCEPT, typeof(Log)),
            new QnameType("handshake", URI.CONNECT, typeof(Handshake)),
            new QnameType("route",     URI.CONNECT, typeof(Route)),
            new QnameType("xdb",       URI.CONNECT, typeof(Xdb)),
            new QnameType("log",       URI.CONNECT, typeof(Log))
        };
        QnameType[] IPacketTypes.Types { get { return s_qnt; } }
    }
}
