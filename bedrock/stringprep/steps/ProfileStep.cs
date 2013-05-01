using System;

using System.Text;

namespace Kixeye.Bedrock.StringPrep.Steps
{
    /// <summary>
    /// Base class for steps in a stringprep profile.
    /// </summary>
    public abstract class ProfileStep
    {
        private string m_name;

        /// <summary>
        /// Create a named profile step, with no flags.
        /// </summary>
        /// <param name="name">The profile name</param>
        protected ProfileStep(string name)
        {
            m_name = name;
        }

        /// <summary>
        /// The name of the step.
        /// </summary>
        public virtual string Name
        {
            get { return m_name; }
        }

        /// <summary>
        /// This is the workhorse function, to be implemented in each subclass.
        /// </summary>
        /// <param name="result">Result will be modified in place</param>
        public abstract void Prepare(StringBuilder result);
    }
}
