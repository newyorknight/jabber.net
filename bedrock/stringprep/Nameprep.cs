using System;

using Kixeye.Bedrock.StringPrep.Steps;

namespace Kixeye.Bedrock.StringPrep
{
    /// <summary>
    /// RFC 3491, "nameprep" profile, for internationalized domain names.
    /// </summary>
    public class Nameprep : Profile
    {
        /// <summary>
        /// Create a nameprep instance.
        /// </summary>
        public Nameprep() :
            base( new ProfileStep[] {   B_1, B_2, NFKC,
                                        C_1_2, C_2_2, C_3, C_4, C_5, C_6, C_7, C_8, C_9,
                                        BIDI, UNASSIGNED} )
        {
        }
    }
}
