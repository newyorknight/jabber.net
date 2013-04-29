using System;


using bedrock.util;
using jabber.protocol;

namespace jabber.protocol.x
{
    /// <summary>
    /// ElementFactory for all currently supported IQ namespaces.
    /// </summary>
    public class Factory : IPacketTypes
    {
        private static QnameType[] s_qnt = new QnameType[]
        {
                    new QnameType("x",     URI.XDELAY,    typeof(jabber.protocol.x.Delay)),
                    new QnameType("x",     URI.XEVENT,    typeof(jabber.protocol.x.Event)),
                    new QnameType("x",     URI.XOOB,      typeof(jabber.protocol.iq.OOB)),
                    new QnameType("x",     URI.XROSTER,   typeof(jabber.protocol.iq.Roster)),
                    new QnameType("item",  URI.XROSTER,   typeof(jabber.protocol.iq.Item)),
                    new QnameType("group", URI.XROSTER,   typeof(jabber.protocol.iq.Group)),

                    new QnameType("x",     URI.XDATA,     typeof(jabber.protocol.x.Data)),
                    new QnameType("field", URI.XDATA,     typeof(jabber.protocol.x.Field)),
                    new QnameType("option",URI.XDATA,     typeof(jabber.protocol.x.Option)),

                    new QnameType("c",     URI.CAPS,      typeof(jabber.protocol.x.Caps)),
        };
        QnameType[] IPacketTypes.Types { get { return s_qnt; } }
    }
}
