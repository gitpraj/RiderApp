using NUnit.Framework;
using RiderApp.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Set up Prerequisites   
            var controller = new RiderApp.Controllers.RiderController();
            //SampleD objRider = new RiderDataAcessLayer();
            //objRider.GetRiderData(1);
            ////controller.Request = newHttpRequestMessage();
            ////controller.Configuration = newHttpConfiguration();
            //// Act on Test  
            //var response = controller.Details(1);
            //// Assert the result

            Assert.AreEqual(1,1);
        }
    }
}