using System;


using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Protocol;

namespace Kixeye.Jabber.Protocol.IQ
{
    /// <summary>
    /// ElementFactory for all currently supported IQ namespaces.
    /// </summary>
    public class Factory : IPacketTypes
    {
        private static QnameType[] s_qnt = new QnameType[]
        {
            new QnameType("query", URI.AUTH,     typeof(Kixeye.Jabber.Protocol.IQ.Auth)),
            new QnameType("query", URI.REGISTER, typeof(Kixeye.Jabber.Protocol.IQ.Register)),
            new QnameType("query", URI.ROSTER,   typeof(Kixeye.Jabber.Protocol.IQ.Roster)),
            new QnameType("item",  URI.ROSTER,   typeof(Kixeye.Jabber.Protocol.IQ.Item)),
            new QnameType("group", URI.ROSTER,   typeof(Kixeye.Jabber.Protocol.IQ.Group)),
            new QnameType("query", URI.AGENTS,   typeof(Kixeye.Jabber.Protocol.IQ.AgentsQuery)),
            new QnameType("agent", URI.AGENTS,   typeof(Kixeye.Jabber.Protocol.IQ.Agent)),
            new QnameType("query", URI.OOB,      typeof(Kixeye.Jabber.Protocol.IQ.OOB)),
            new QnameType("query", URI.TIME,     typeof(Kixeye.Jabber.Protocol.IQ.Time)),
            new QnameType("query", URI.VERSION,  typeof(Kixeye.Jabber.Protocol.IQ.Version)),
            new QnameType("query", URI.LAST,     typeof(Kixeye.Jabber.Protocol.IQ.Last)),
            new QnameType("item",  URI.BROWSE,   typeof(Kixeye.Jabber.Protocol.IQ.Browse)),
            new QnameType("geoloc",URI.GEOLOC,   typeof(Kixeye.Jabber.Protocol.IQ.GeoLoc)),
            
            
            new QnameType("query",      URI.PRIVATE,   typeof(Kixeye.Jabber.Protocol.IQ.Private)),
            new QnameType("storage",    URI.BOOKMARKS, typeof(Kixeye.Jabber.Protocol.IQ.Bookmarks)),
            new QnameType("url",        URI.BOOKMARKS, typeof(Kixeye.Jabber.Protocol.IQ.BookmarkURL)),
            new QnameType("conference", URI.BOOKMARKS, typeof(Kixeye.Jabber.Protocol.IQ.BookmarkConference)),
            new QnameType("note",       URI.BOOKMARKS, typeof(Kixeye.Jabber.Protocol.IQ.BookmarkNote)),

            // VCard
            new QnameType("vCard", URI.VCARD, typeof(Kixeye.Jabber.Protocol.IQ.VCard)),
            new QnameType("N",     URI.VCARD, typeof(Kixeye.Jabber.Protocol.IQ.VCard.VName)),
            new QnameType("ORG",   URI.VCARD, typeof(Kixeye.Jabber.Protocol.IQ.VCard.VOrganization)),
            new QnameType("TEL",   URI.VCARD, typeof(Kixeye.Jabber.Protocol.IQ.VCard.VTelephone)),
            new QnameType("EMAIL", URI.VCARD, typeof(Kixeye.Jabber.Protocol.IQ.VCard.VEmail)),
            new QnameType("GEO",   URI.VCARD, typeof(Kixeye.Jabber.Protocol.IQ.VCard.VGeo)),
            new QnameType("PHOTO", URI.VCARD, typeof(Kixeye.Jabber.Protocol.IQ.VCard.VPhoto)),
            new QnameType("ADR", URI.VCARD, typeof(Kixeye.Jabber.Protocol.IQ.VCard.VAddress)),

            // Disco
            new QnameType("query",    URI.DISCO_ITEMS, typeof(Kixeye.Jabber.Protocol.IQ.DiscoItems)),
            new QnameType("item",     URI.DISCO_ITEMS, typeof(Kixeye.Jabber.Protocol.IQ.DiscoItem)),
            new QnameType("query",    URI.DISCO_INFO, typeof(Kixeye.Jabber.Protocol.IQ.DiscoInfo)),
            new QnameType("identity", URI.DISCO_INFO, typeof(Kixeye.Jabber.Protocol.IQ.DiscoIdentity)),
            new QnameType("feature",  URI.DISCO_INFO, typeof(Kixeye.Jabber.Protocol.IQ.DiscoFeature)),

            // PubSub
            new QnameType("pubsub",        URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.PubSub)),
            new QnameType("affiliations",  URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.Affiliations)),
            new QnameType("create",        URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.Create)),
            new QnameType("items",         URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.Items)),
            new QnameType("publish",       URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.Publish)),
            new QnameType("retract",       URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.Retract)),
            new QnameType("subscribe",     URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.Subscribe)),
            new QnameType("subscriptions", URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.Subscriptions)),
            new QnameType("unsubscribe",   URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.Unsubscribe)),

            new QnameType("configure",     URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.Configure)),
            new QnameType("options",       URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.PubSubOptions)),
            new QnameType("affiliation",   URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.Affiliation)),
            new QnameType("item",          URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.PubSubItem)),
            new QnameType("subscription",  URI.PUBSUB, typeof(Kixeye.Jabber.Protocol.IQ.PubSubSubscription)),

            // Pubsub event notifications
            new QnameType("event",         URI.PUBSUB_EVENT, typeof(Kixeye.Jabber.Protocol.IQ.PubSubEvent)),
            new QnameType("associate",     URI.PUBSUB_EVENT, typeof(Kixeye.Jabber.Protocol.IQ.EventAssociate)),
            new QnameType("collection",    URI.PUBSUB_EVENT, typeof(Kixeye.Jabber.Protocol.IQ.EventCollection)),
            new QnameType("configuration", URI.PUBSUB_EVENT, typeof(Kixeye.Jabber.Protocol.IQ.EventConfiguration)),
            new QnameType("disassociate",  URI.PUBSUB_EVENT, typeof(Kixeye.Jabber.Protocol.IQ.EventDisassociate)),
            new QnameType("items",         URI.PUBSUB_EVENT, typeof(Kixeye.Jabber.Protocol.IQ.EventItems)),
            new QnameType("item",          URI.PUBSUB_EVENT, typeof(Kixeye.Jabber.Protocol.IQ.PubSubItem)),
            new QnameType("purge",         URI.PUBSUB_EVENT, typeof(Kixeye.Jabber.Protocol.IQ.EventPurge)),
            new QnameType("retract",       URI.PUBSUB_EVENT, typeof(Kixeye.Jabber.Protocol.IQ.EventRetract)),
            new QnameType("subscription",  URI.PUBSUB_EVENT, typeof(Kixeye.Jabber.Protocol.IQ.EventSubscription)),

            // Pubsub owner use cases
            new QnameType("pubsub",        URI.PUBSUB_OWNER, typeof(Kixeye.Jabber.Protocol.IQ.PubSubOwner)),
            new QnameType("affiliations",  URI.PUBSUB_OWNER, typeof(Kixeye.Jabber.Protocol.IQ.OwnerAffliliations)),
            new QnameType("affiliation",   URI.PUBSUB_OWNER, typeof(Kixeye.Jabber.Protocol.IQ.OwnerAffiliation)),
            new QnameType("configure",     URI.PUBSUB_OWNER, typeof(Kixeye.Jabber.Protocol.IQ.OwnerConfigure)),
            new QnameType("default",       URI.PUBSUB_OWNER, typeof(Kixeye.Jabber.Protocol.IQ.OwnerDefault)),
            new QnameType("delete",        URI.PUBSUB_OWNER, typeof(Kixeye.Jabber.Protocol.IQ.OwnerDelete)),
            new QnameType("purge",         URI.PUBSUB_OWNER, typeof(Kixeye.Jabber.Protocol.IQ.OwnerPurge)),
            new QnameType("subscriptions", URI.PUBSUB_OWNER, typeof(Kixeye.Jabber.Protocol.IQ.OwnerSubscriptions)),
            new QnameType("subscription",  URI.PUBSUB_OWNER, typeof(Kixeye.Jabber.Protocol.IQ.PubSubSubscription)),

            // Pubsub errors
            new QnameType("closed-node",                    URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.ClosedNode)),
            new QnameType("configuration-required",         URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.ConfigurationRequired)),
            new QnameType("invalid-jid",                    URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.InvalidJID)),
            new QnameType("invalid-options",                URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.InvalidOptions)),
            new QnameType("invalid-payload",                URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.InvalidPayload)),
            new QnameType("invalid-subid",                  URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.InvalidSubid)),
            new QnameType("item-forbidden",                 URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.ItemForbidden)),
            new QnameType("item-required",                  URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.ItemRequired)),
            new QnameType("jid-required",                   URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.JIDRequired)),
            new QnameType("max-items-exceeded",             URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.MaxItemsExceeded)),
            new QnameType("max-nodes-exceeded",             URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.MaxNodesExceeded)),
            new QnameType("nodeid-required",                URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.NodeIDRequired)),
            new QnameType("not-in-roster-group",            URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.NotInRosterGroup)),
            new QnameType("not-subscribed",                 URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.NotSubscribed)),
            new QnameType("payload-too-big",                URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.PayloadTooBig)),
            new QnameType("payload-required",               URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.PayloadRequired)),
            new QnameType("pending-subscription",           URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.PendingSubscription)),
            new QnameType("presence-subscription-required", URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.PresenceSubscriptionRequired)),
            new QnameType("subid-required",                 URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.SubidRequired)),
            new QnameType("unsupported",                    URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.Unsupported)),
            new QnameType("unsupported-access-model",       URI.PUBSUB_ERRORS, typeof(Kixeye.Jabber.Protocol.IQ.UnsupportedAccessModel)),

            // Multi-user chat
            new QnameType("x",       URI.MUC, typeof(Kixeye.Jabber.Protocol.IQ.RoomX)),
            new QnameType("history", URI.MUC, typeof(Kixeye.Jabber.Protocol.IQ.History)),

            new QnameType("x",       URI.MUC_USER, typeof(Kixeye.Jabber.Protocol.IQ.UserX)),
            new QnameType("decline", URI.MUC_USER, typeof(Kixeye.Jabber.Protocol.IQ.Decline)),
            new QnameType("invite",  URI.MUC_USER, typeof(Kixeye.Jabber.Protocol.IQ.Invite)),
            new QnameType("destroy", URI.MUC_USER, typeof(Kixeye.Jabber.Protocol.IQ.Destroy)),
            new QnameType("item",    URI.MUC_USER, typeof(Kixeye.Jabber.Protocol.IQ.RoomItem)),
            new QnameType("actor",   URI.MUC_USER, typeof(Kixeye.Jabber.Protocol.IQ.RoomActor)),

            new QnameType("query",   URI.MUC_ADMIN, typeof(Kixeye.Jabber.Protocol.IQ.AdminQuery)),
            new QnameType("item",    URI.MUC_ADMIN, typeof(Kixeye.Jabber.Protocol.IQ.AdminItem)),

            new QnameType("query",   URI.MUC_OWNER, typeof(Kixeye.Jabber.Protocol.IQ.OwnerQuery)),
            new QnameType("destroy", URI.MUC_OWNER, typeof(Kixeye.Jabber.Protocol.IQ.OwnerDestroy)),
        };

        public QnameType[] Types { get { return s_qnt; } }
    }
}
