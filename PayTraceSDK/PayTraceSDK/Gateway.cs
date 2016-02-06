using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayTraceSDK
{
    public  class Gateway
    {
        public string Connection { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        
        public Gateway()
        {

        }

        public Gateway(string connection, string publicKey, string privateKey)
        {
            Connection = connection;
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }


        public virtual TransactionGateway Transactions
        {
            get
            {
                throw new NotFiniteNumberException(); // return new TransactionGateway(); }
            }
        }


        
    }
}
