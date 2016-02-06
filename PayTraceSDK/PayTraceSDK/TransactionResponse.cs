using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PayTraceSDK
{
    public class TransactionResponse : IWebResponse
    {
     
        
        public TransactionResponse(string json) 
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string,string>>(json); 

            if( string.IsNullOrEmpty(json))
            {
                    
            }


            //var goodResponse = "{\"success\":true,\"response_code\":101,\"status_message\":\"Your transaction was successfully approved.\",\"transaction_id\":76465308,\"approval_code\":\"TAS091\",\"approval_message\":\"APPROVAL TAS091  - Approved and completed\",\"avs_response\":\"0\",\"csc_response\":\"\",\"external_transaction_id\":\"\",\"masked_card_number\":\"xxxxxxxxxxxx1111\"}";
            IsSuccess = Convert.ToBoolean(dict["success"]);
            ResponseCode = dict["response_code"];
            StatusMessage = dict["status_message"] ?? null;
            TransactionID = ParseAsInt(dict["transaction_id"]);
            ApprovalCode = dict["approval_code"];
            ApprovalMessage = dict["approval_message"];
            AVSResponse = dict["avs_response"];
            CSCResponse = dict["csc_response"];
            ExtrenalTransactionID = dict["external_transaction_id"];
            CCLastFour = GetLastFourDigits( dict["masked_card_number"]);

        }

        private string GetLastFourDigits(string cc)
        {
           if (cc.Length <= 4)
           {
               return cc;
           }

           return cc.Substring(cc.Length - 4);
        }
        
        public bool IsSuccess { get; set; }
        public string ResponseCode { get; set;}
        public string StatusMessage { get; set; }
        public int TransactionID { get; set; }
        public string ApprovalCode { get; set; }
        public string ApprovalMessage { get; set; }
        public string AVSResponse { get; set; }
        public string CSCResponse { get; set; }
        public string ExtrenalTransactionID { get; set; }
        public string CCLastFour { get; set; }

        private int ParseAsInt(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            int actual = 0;
            if (Int32.TryParse(value, out actual))
            {
                return actual;
            }
            return 0; 
        }

    }
}
