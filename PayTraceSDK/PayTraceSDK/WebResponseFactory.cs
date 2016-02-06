using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace PayTraceSDK
{
    public class WebResponseFactory
    {
        public IWebResponse GetResponse(HttpWebResponse response)
        {
            IWebResponse PTResponse = null;
            switch(response.StatusCode)
            {
                case HttpStatusCode.BadRequest:

                    return new TransactionResponse(response.StatusDescription);
//                case HttpStatusCode.OK:
  //                  return new TransactionResponse(s response)


            }
            throw new NotImplementedException();
        }

        private IWebResponse Build500Response(WebResponse response)
        {
            return null; 
        }
    }
}
