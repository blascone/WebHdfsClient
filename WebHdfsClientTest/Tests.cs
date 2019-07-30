using System;
using NUnit.Framework;

namespace WebHdfsClientTest {

    [TestFixture]
    public class Tests {

        [Test]
        public void FileStatusTest() {
            WebHdfsClient.WebHdfsClient client = new WebHdfsClient.WebHdfsClient("10.150.0.10","50070");
           Console.WriteLine(client.FileStatus("ciop/run/hands-on-1/0000001-190705175000140-oozie-oozi-W"));
        }
        
        
        [Test]
        public void ListStatusTest() {
            WebHdfsClient.WebHdfsClient client = new WebHdfsClient.WebHdfsClient("10.150.0.10","50070");
            Console.WriteLine(client.ListStatus("ciop/run/hands-on-1/0000001-190705175000140-oozie-oozi-W"));
        }
        
     
        [Test]
        public void OpenTest() {
            WebHdfsClient.WebHdfsClient client = new WebHdfsClient.WebHdfsClient("10.150.0.10","50070");

            Console.WriteLine(client.Open("ciop/run/tg-drm-integration/0000000-190416163227986-oozie-oozi-W/workflow-params.xml"));
        }

    }

}