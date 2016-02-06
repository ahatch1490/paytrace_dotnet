using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayTraceSDK;

namespace PayTraceSDK.Test
{
    [TestClass]
    public class GatewayHarness
    {

        [TestMethod]
        public void should_be_able_to_load_config_values_by_config_properties()
        {
            string expectedConnection = "TestConnection";
            string expectedPublicKey = "PublicKey";
            string expectedPrivateKey = "PrivateKey";
            var test = new Gateway
            {
                Connection = expectedConnection,
                PublicKey = expectedPublicKey,
                PrivateKey = expectedPrivateKey 
                
            };

            Assert.AreEqual(test.Connection,expectedConnection);
            Assert.AreEqual(test.PrivateKey, expectedPrivateKey);
            Assert.AreEqual(test.PublicKey, expectedPublicKey);

        }

        //public should_be_able_to_create_sale()
        //{
        //}

       
    }
}
