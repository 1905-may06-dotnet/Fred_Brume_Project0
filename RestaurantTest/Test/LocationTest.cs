using NUnit.Framework;
using PizzaBox.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace PizzaBox.Testing.Test
{

    [TestFixture]
    class LocationTest
    {

       [Test]
        public void Locationtest()
        {
            List<Plocation> locations = new Crud().GetLocations();

            var location = locations.Where(l => l.LocationId == 1).First();

            Assert.AreEqual("Brokyln", location.City);

        }


    }
}
