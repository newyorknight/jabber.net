using System;
using System.Text;
using System.IO;
using System.Threading;

using NUnit.Framework;
using Kixeye.Bedrock.Util;
using Kixeye.Jabber.Connection;

namespace test.kixeye.jabber.net
{
    /// <summary>
    /// TODO: This test is known to not work.  Add one that does, please.
    /// </summary>
    [TestFixture]
    public class HttpUploadTest
    {
        private object m_lock = new object();

        private void uploader_OnUpload(object sender)
        {
            lock(m_lock)
            {
                Monitor.Pulse(m_lock);
            }
        }

        [Test]
        public void UploadFile()
        {
            /*
            m_lock = new object();

            HttpUploader uploader = new HttpUploader();
            uploader.OnUpload += new global::kixeye.bedrock.ObjectHandler(uploader_OnUpload);
            uploader.Upload("http://opodsadny.kiev.luxoft.com:7335/webclient", "les@primus.com/Bass", "upload.txt");
            lock (m_lock)
            {
                Monitor.Wait(m_lock);
            }
             */
        }
    }
}
