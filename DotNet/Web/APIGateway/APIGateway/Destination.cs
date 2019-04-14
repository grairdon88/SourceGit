using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIGateway {
    public class Destination {
        #region Constants, Fields and Enums
        public string URL { get; set; }

        public bool RequiresAuthentication { get; set; }

        static HttpClient client = new HttpClient();
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requiresAuthentication"></param>
        public Destination(string url, bool requiresAuthentication) {
            URL = url;
            RequiresAuthentication = requiresAuthentication;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public Destination(string url) : this(url, false) {

        }

        /// <summary>
        /// Private constructor.
        /// </summary>
        private Destination() {
            URL = "/";
            RequiresAuthentication = false;
        }
        #endregion

        #region Method: CreateDestinationURL
        /// <summary>
        /// Creates a destination URL.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string CreateDestinationURL(HttpRequest request) {
            string requestPath = request.Path.ToString();
            string queryString = request.QueryString.ToString();

            string endpoint = string.Empty;
            string[] endpointSplit = requestPath.Substring(1).Split("/");

            if(endpointSplit.Length > 1) 
                endpoint = endpointSplit[1];

            return URL + endpoint + queryString;
        }
        #endregion

        #region Method: SendRequest
        /// <summary>
        /// Takes in an http request and forwards it.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> SendRequest(HttpRequest request) {
            string requestContent = string.Empty;

            using(Stream receiveStream = request.Body) {
                using(StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8)) {
                    requestContent = readStream.ReadToEnd();
                }
            }

            using(HttpRequestMessage newRequest = new HttpRequestMessage(new HttpMethod(request.Method), CreateDestinationURL(request))) {
                newRequest.Content = new StringContent(requestContent, System.Text.Encoding.UTF8, request.ContentType);
                return await client.SendAsync(newRequest);
            }
        }
        #endregion
    }
}
