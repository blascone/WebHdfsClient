using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;


namespace WebHdfsClient {

    public class WebHdfsClient {

        private HttpWebRequest client;
        private readonly string hdfsUrl;

        
        // GET OPERATIONS
        public const string GET_OPERATION_OPEN = "OPEN";
        public const string GET_OPERATION_GETFILESTATUS = "GETFILESTATUS";
        public const string GET_OPERATION_LISTSTATUS = "LISTSTATUS";
        
        public const string DEFAULT_HTTP_WEBHDFS_PORT = "50075";
        public const string DEFAULT_HTTP_WEBHDFS_VERSION = "v1";
        
        
        public WebHdfsClient(string host, string port = DEFAULT_HTTP_WEBHDFS_PORT, string version = DEFAULT_HTTP_WEBHDFS_VERSION) {
            hdfsUrl = $"http://{host}:{port}/webhdfs/{version}";
        }


        private string GetRequest(string folder, string requestType, Dictionary<string, string> optionalParameters = null) {
            var optionalparams = "";
            if (optionalParameters != null) {
                optionalparams = string.Join("&", optionalParameters.Select(x => x.Key + "=" + x.Value).ToArray());
            }

            var urlrequest = $"{hdfsUrl}/{folder}/?op={requestType}&{optionalparams}";
            Console.WriteLine(urlrequest);
            client = (HttpWebRequest) WebRequest.Create(urlrequest);
            var response = client.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            return content;
        }


        public string Open(string folder, int offset = 0, string contentlength = null, string buffersize = null) {
            var parameters = new Dictionary<string, string>();
            if (offset != 0) parameters.Add("offset", offset.ToString());
            if (contentlength != null) parameters.Add("length", contentlength);
            if (buffersize != null) parameters.Add("buffersize", buffersize);

            return GetRequest(folder, GET_OPERATION_OPEN, parameters);
        }


        public string FileStatus(string folder) {
            return GetRequest(folder, GET_OPERATION_GETFILESTATUS);
        }

        public string ListStatus(string folder) {
            return GetRequest(folder, GET_OPERATION_LISTSTATUS);
        }

    }

}