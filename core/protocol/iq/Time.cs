using System;

using System.Xml;

using Kixeye.Bedrock.Util;

namespace Kixeye.Jabber.Protocol.IQ
{
    /*
     * <iq type="result" to="romeo@montague.net/orchard"
     *                   from="juliet@capulet.com/balcony"
     *                   id="i_time_001">
     *   <query xmlns="jabber:iq:time">
     *     <utc>20020214T23:55:06</utc>
     *     <tz>WET</tz>
     *     <display>14 Feb 2002 11:55:06 PM</display>
     *   </query>
     * </iq>
     */
    /// <summary>
    /// IQ packet with an time query element inside.
    /// </summary>
    public class TimeIQ : Kixeye.Jabber.Protocol.Client.TypedIQ<Time>
    {
        /// <summary>
        /// Create a time IQ
        /// </summary>
        /// <param name="doc"></param>
        public TimeIQ(XmlDocument doc) : base(doc)
        {
        }
    }

    /// <summary>
    /// A time query element.
    /// </summary>
    public class Time : Element
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="doc"></param>
        public Time(XmlDocument doc) : base("query", URI.TIME, doc)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Time(string prefix, XmlQualifiedName qname, XmlDocument doc) :
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// Set the current UTC, TZ, and Display based on the machine's current settings/locale.
        /// </summary>
        public void SetCurrentTime()
        {
            DateTime dt = DateTime.Now;
            UTC = dt.ToUniversalTime();
            TZ = TimeZone.CurrentTimeZone.IsDaylightSavingTime(dt) ?
                TimeZone.CurrentTimeZone.DaylightName : TimeZone.CurrentTimeZone.StandardName;
            Display = dt.ToLongDateString() + " " + dt.ToLongTimeString();
        }

        /// <summary>
        /// Universal coordinated time.  (More or less GMT).
        /// </summary>
        public DateTime UTC
        {
            get { return JabberDate(GetElem("utc")); }
            set { SetElem("utc", JabberDate(value)); }
        }

        /// <summary>
        /// Timezone
        /// </summary>
        //TODO: return System.TimeZone?
        public string TZ
        {
            get { return GetElem("tz"); }
            set { SetElem("tz", value); }
        }

        /// <summary>
        /// Human-readable date/time.
        /// </summary>
        public string Display
        {
            get { return GetElem("display"); }
            set { SetElem("display", value); }
        }
    }
}