using NUnit.Framework;
using RiderApp.Models;
using System;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // testing adding rider with random emailId
        [Test]
        public void Test1()
        {
            // Set up Prerequisites   
            var controller = new RiderApp.Controllers.RiderController();

            Rider rider = new Rider();
            Random random = new Random();
            rider.FirstName = "dummyfn";
            rider.LastName = "dummyln";
            rider.PhoneNumber = "0490789" + random.Next(0, 1000);
            rider.Email = "dummy" + random.Next(0, 1000) + "@email.com";

            int res = controller.Create(rider);

            Assert.AreEqual(1, res);
        }

        // testing adding rider with already exisiting email ID
        [Test]
        public void Test2()
        {
           var controller = new RiderApp.Controllers.RiderController();

            Rider rider = new Rider();
            rider.FirstName = "dummyfn";
            rider.LastName = "dummyln";
            rider.PhoneNumber = "0490789123";
            rider.Email = "dummy@email.com";

            int res = controller.Create(rider);

            Assert.AreEqual(-1, res);
        }

        // testing updating rider with new emailID
        [Test]
        public void Test3()
        {
            var controller = new RiderApp.Controllers.RiderController();

            Rider rider = new Rider();
            Random random = new Random();
            rider.Id = 12;
            rider.StartDate = DateTime.Now;
            rider.FirstName = "Updated";
            rider.LastName = "Name";
            rider.PhoneNumber = "0490789123";
            rider.Email = "updated" + random.Next(0, 1000) + "@email.com";

            int res = controller.Edit(rider);

            Assert.AreEqual(1, res);
        }

        // testing updating rider with existing emailID
        [Test]
        public void Test4()
        {
            var controller = new RiderApp.Controllers.RiderController();

            Rider rider = new Rider();
            rider.Id = 12;
            rider.StartDate = DateTime.Now;
            rider.FirstName = "dummyfn";
            rider.LastName = "dummyln";
            rider.PhoneNumber = "0490789123";
            rider.Email = "dummy@email.com";

            int res = controller.Edit(rider);

            Assert.AreEqual(-1, res);
        }

        // testing delete rider for a rider that does or does not have jobs
        [Test]
        public void Test5()
        {
            var controller = new RiderApp.Controllers.RiderController();
            RiderAppContext db = new RiderAppContext();
            int riderID = 4;
            int res = -1;
            if (db.Rider.Any(o => o.Id == riderID))
            {
                res = controller.Delete(riderID);
                Assert.AreEqual(1, res);
            } else
            {
                Assert.AreEqual(-1, res);
            }
        }
    }
}