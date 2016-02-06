using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayTraceSDK;
namespace PayTraceSDK.Test
{
    [TestClass]
    public class TransactionRequestHarness 
    {
        [TestMethod]
        public void should_handle_500_error()
        {

            var factory = new PayTraceSDK.WebResponseFactory(); 
        }       
    }
}
