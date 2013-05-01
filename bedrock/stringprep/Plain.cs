using System;

using Kixeye.Bedrock.StringPrep.Steps;

namespace Kixeye.Bedrock.StringPrep
{
    /// <summary>
    /// A relatively plain stringprep profile, that doesn't do case folding, or prevent unassigned characters.
    /// </summary>
    public class Plain : Profile
    {
        /// <summary>
        /// Create a Plain instance.
        /// </summary>
        public Plain() :
            base( new ProfileStep[] {   C_2_1, C_2_2,
                                        C_3, C_4, C_5, C_6, C_8, C_9,
                                        BIDI } )
        {
        }
    }
}
