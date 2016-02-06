using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayTraceSDK
{
    public class TransactionGateway
    {
        private IAuthConfiguration AuthConfig;

        public TransactionGateway(IAuthConfiguration config)
        {
            AuthConfig = config;
        }

        public TransactionResponse Sale(TransactionRequest request)
        {

           // var response = AuthConfig.SendRequest();
            //return new TransactionResponse(response);
            throw new NotImplementedException();
        }

    }
}
