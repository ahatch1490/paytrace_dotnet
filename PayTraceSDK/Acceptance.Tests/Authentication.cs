using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayTraceSDK;
using System.Net;
using System.IO;
using PayTraceSDK;

namespace Acceptance.Tests
{
    /// <summary>
    /// Summary description for Authentication
    /// </summary>
    [TestClass]
    public class Authentication
    {
        public Authentication()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Basic_transaction()
        {
            var auth = new DotNetOpenAuthConfiguration("demo123", "demo123");
            var keySale = new { amount = 19.95, credit_card = new { number = "4111111111111111", expiration_month = 12, expiration_year = 20 } };
            var response = auth.SendRequest(keySale, "transactions/sale/keyed");
            var str = response.GetResponseStream();
            StreamReader r = new StreamReader(str);
            TestContext.WriteLine(r.ReadToEnd());

        }

        [TestMethod]
        public void Basic_Decline_transaction()
        {
            var auth = new DotNetOpenAuthConfiguration("demo123", "demo123");
            var keySale = new { amount = "0.20", credit_card = new { number = "4111111111111111", expiration_month = 12, expiration_year = 20 } };
            var response = auth.SendRequest(keySale, "transactions/sale/keyed");
            var str = response.GetResponseStream();
            StreamReader r = new StreamReader(str);
           TestContext.WriteLine( r.ReadToEnd());
        }
    }    
}
