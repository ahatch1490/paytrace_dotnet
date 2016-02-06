using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayTraceSDK
{
    public class CreditCard
    {
        public string Number { get; set; }
        public string ExperationDate { get; set; }
        public string FullName { get; set; }
        public Address BillingAddress { get; set;}
    }
}
