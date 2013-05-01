using System;


using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol;

namespace Kixeye.Jabber.Protocol.X
{
    /// <summary>
    /// ElementFactory for all currently supported IQ namespaces.
    /// </summary>
    public class Factory : IPacketTypes
    {
        private static QnameType[] s_qnt = new QnameType[]
        {
                    new QnameType("x",     URI.XDELAY,    typeof(Kixeye.Jabber.Protocol.X.Delay)),
                    new QnameType("x",     URI.XEVENT,    typeof(Kixeye.Jabber.Protocol.X.Event)),
                    new QnameType("x",     URI.XOOB,      typeof(Kixeye.Jabber.Protocol.IQ.OOB)),
                    new QnameType("x",     URI.XROSTER,   typeof(Kixeye.Jabber.Protocol.IQ.Roster)),
                    new QnameType("item",  URI.XROSTER,   typeof(Kixeye.Jabber.Protocol.IQ.Item)),
                    new QnameType("group", URI.XROSTER,   typeof(Kixeye.Jabber.Protocol.IQ.Group)),

                    new QnameType("x",     URI.XDATA,     typeof(Kixeye.Jabber.Protocol.X.Data)),
                    new QnameType("field", URI.XDATA,     typeof(Kixeye.Jabber.Protocol.X.Field)),
                    new QnameType("option",URI.XDATA,     typeof(Kixeye.Jabber.Protocol.X.Option)),

                    new QnameType("c",     URI.CAPS,      typeof(Kixeye.Jabber.Protocol.X.Caps)),
        };
        QnameType[] IPacketTypes.Types { get { return s_qnt; } }
    }
}
