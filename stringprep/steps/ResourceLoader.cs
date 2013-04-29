using System;

using System.Resources;
using System.Reflection;

namespace stringprep.steps
{
    class ResourceLoader
    {
        private const string RFC3454 = "stringprep.steps.rfc3454";
        private static ResourceManager m_rfc_res = null;

        private static ResourceManager Resources
        {
            get
            {
                if (m_rfc_res == null)
                {
                    lock (RFC3454)
                    {
                        if (m_rfc_res == null)
                            m_rfc_res = new ResourceManager(RFC3454, Assembly.GetExecutingAssembly());
                    }
                }
                return m_rfc_res;
            }
        }

        public static object LoadRes(string name)
        {
            return Resources.GetObject(name);
        }
    }
}
