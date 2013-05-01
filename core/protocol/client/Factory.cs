using System;

using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol;

namespace Kixeye.Jabber.Protocol.Client
{
    /// <summary>
    /// ElementFactory for the jabber:client namespace.
    /// </summary>
    public class Factory : IPacketTypes
    {
        private static QnameType[] s_qnt = new QnameType[]
        {
            new QnameType("presence", URI.CLIENT, typeof(Kixeye.Jabber.Protocol.Client.Presence)),
            new QnameType("message",  URI.CLIENT, typeof(Kixeye.Jabber.Protocol.Client.Message)),
            new QnameType("iq",       URI.CLIENT, typeof(Kixeye.Jabber.Protocol.Client.IQ)),
            new QnameType("error",    URI.CLIENT, typeof(Kixeye.Jabber.Protocol.Client.Error)),
            // meh.  jabber protocol really isn't right WRT to namespaces.
            new QnameType("presence", URI.ACCEPT, typeof(Kixeye.Jabber.Protocol.Client.Presence)),
            new QnameType("message",  URI.ACCEPT, typeof(Kixeye.Jabber.Protocol.Client.Message)),
            new QnameType("iq",       URI.ACCEPT, typeof(Kixeye.Jabber.Protocol.Client.IQ)),
            new QnameType("error",    URI.ACCEPT, typeof(Kixeye.Jabber.Protocol.Client.Error))
        };
        public QnameType[] Types { get { return s_qnt; } }
    }
}
