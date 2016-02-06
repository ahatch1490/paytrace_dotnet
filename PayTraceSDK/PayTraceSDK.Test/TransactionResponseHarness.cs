using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayTraceSDK;
namespace PayTraceSDK.Test
{
    [TestClass]
    public class TransactionResponseHarness 
    {
        [TestMethod]
        public void Should_be_able_to_parse_a_successful_transaction_response()
        {
            var goodResponse = "{\"success\":true,\"response_code\":101,\"status_message\":\"Your transaction was successfully approved.\",\"transaction_id\":76465308,\"approval_code\":\"TAS091\",\"approval_message\":\"APPROVAL TAS091  - Approved and completed\",\"avs_response\":\"0\",\"csc_response\":\"\",\"external_transaction_id\":\"\",\"masked_card_number\":\"xxxxxxxxxxxx1111\"}";
            var actual = new TransactionResponse(goodResponse);

            Assert.IsTrue(actual.IsSuccess);
            Assert.IsTrue(actual.ResponseCode == "101");
            Assert.AreEqual(actual.StatusMessage, "Your transaction was successfully approved.");
            Assert.AreEqual(actual.TransactionID, 76465308);
            Assert.AreEqual(actual.ApprovalCode, "TAS091");
            Assert.AreEqual(actual.ApprovalMessage, "APPROVAL TAS091  - Approved and completed");
            Assert.AreEqual(actual.AVSResponse, "0");
            Assert.AreEqual(actual.CSCResponse, string.Empty);
            Assert.AreEqual(actual.ExtrenalTransactionID, "");
            Assert.AreEqual(actual.CCLastFour, "1111");
        }

    }
}
