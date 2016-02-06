using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetOpenAuth;
using DotNetOpenAuth.OAuth2;
using Newtonsoft.Json;
using System.Net;
using System.IO; 

namespace PayTraceSDK
{
    public class DotNetOpenAuthConfiguration : PayTraceSDK.IAuthConfiguration
    {
        const String APIURL = "https://api.paytrace.com"; 
        //const String APIURL = "https://216.109.134.22:4343";
        private AuthorizationServerDescription AuthOath { get; set; }
        private IAuthorizationState auth { get; set; }
        private WebServerClient client { get; set; }
        private string SDKVersion = "";
        
        public DotNetOpenAuthConfiguration(string userName,string password)
        {
            AuthOath = new AuthorizationServerDescription
            {
                TokenEndpoint = new Uri(APIURL + "/oauth/token"),
                ProtocolVersion = ProtocolVersion.V20
            };
            SDKVersion = @"/v1/";
            client = new WebServerClient(AuthOath, APIURL + "/oauth/token");
            auth = client.ExchangeUserCredentialForToken(userName, password);
        }
        
        public WebResponse  SendRequest(Object obj, string url )
        {
            var json = JsonConvert.SerializeObject(obj);
            byte[] buf = Encoding.UTF8.GetBytes(json);
            
            // build request
            var request = (HttpWebRequest)WebRequest.Create(APIURL + SDKVersion + url);
            request.ContentType = @"application/json";
            request.Method = "POST";
            request.ContentLength = buf.Length;
            
            // add our auth token 
            client.AuthorizeRequest(request, auth);
            // buffer the body
            request.GetRequestStream().Write(buf, 0, buf.Length);
            WebResponse response = null; 
            
            try
            {
               response = request.GetResponse();
            }
            catch (WebException e)
            {
                response = e.Response;
            }
       
            return response;
        }

        
       

    }
}
