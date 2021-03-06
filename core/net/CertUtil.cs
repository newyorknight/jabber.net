using System;

#if !NO_SSL && !NET20  && !__MonoCS__
using Org.Mentalis.Security.Certificates;
using Kixeye.Bedrock.Util;

namespace Kixeye.Jabber.Net
{
    /// <summary>
    /// Utilities for creating certificates
    /// </summary>
    public class CertUtil
    {
        /// <summary>
        /// Can this cert be used for server authentication?
        /// </summary>
        private const string OID_PKIX_KP_SERVER_AUTH = "1.3.6.1.5.5.7.3.1";
        /// <summary>
        /// Can this cert be used for client authentication?
        /// </summary>
        private const string OID_PKIX_KP_CLIENT_AUTH = "1.3.6.1.5.5.7.3.2";

        /// <summary>
        /// Find a server certificate in the given store.
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static Certificate FindServerCert(CertificateStore store)
        {
            // return store.FindCertificate(new string[] {OID_PKIX_KP_SERVER_AUTH});
            return store.FindCertificateByUsage(new string[] {OID_PKIX_KP_SERVER_AUTH});
        }

        /// <summary>
        /// Find a client certificate in the given store.
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static Certificate FindClientCert(CertificateStore store)
        {
            //return store.FindCertificate(new string[] {OID_PKIX_KP_CLIENT_AUTH});
            return store.FindCertificateByUsage(new string[] {OID_PKIX_KP_CLIENT_AUTH});
        }
    }
}
#endif
