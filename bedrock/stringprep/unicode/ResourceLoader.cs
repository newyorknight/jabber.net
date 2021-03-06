using System;

using System.Resources;
using System.Reflection;

namespace stringprep.unicode
{
    class ResourceLoader
    {
        private const string UNICODE = "stringprep.unicode.Unicode";
        private static ResourceManager m_uni_res = null;

        private static ResourceManager Resources
        {
            get
            {
                if (m_uni_res == null)
                {
                    lock (UNICODE)
                    {
                        if (m_uni_res == null)
                            m_uni_res = new ResourceManager(UNICODE, Assembly.GetExecutingAssembly());
                    }
                }
                return m_uni_res;
            }
        }

        public static object LoadRes(string name)
        {
            return Resources.GetObject(name);
        }
    }
}
