using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MealPracticum.Test
{
    [TestClass]
    public class FunctionalTests
    {
        [TestMethod]
        public void FunctionalTestStandard()
        {
            var timeOfDay = new TimeOfDay("morning");
            var inputDishes = "1,2,3";
            var expectedOutput = "eggs, toast, coffee";

            var output = Program.GetOutput(timeOfDay, inputDishes);

            Assert.IsNotNull(output);
            Assert.IsTrue(string.Equals(output, expectedOutput));
        }

        [TestMethod]
        public void FunctionalTestSorting()
        {
            var timeOfDay = new TimeOfDay("morning");
            var inputDishes = "2,1,3";
            var expectedOutput = "eggs, toast, coffee";

            var output = Program.GetOutput(timeOfDay, inputDishes);

            Assert.IsNotNull(output);
            Assert.IsTrue(string.Equals(output, expectedOutput));
        }

        [TestMethod]
        public void FunctionalTestWithError()
        {
            var timeOfDay = new TimeOfDay("morning");
            var inputDishes = "1,2,3,4";
            var expectedOutput = "eggs, toast, coffee, error";

            var output = Program.GetOutput(timeOfDay, inputDishes);

            Assert.IsNotNull(output);
            Assert.IsTrue(string.Equals(output, expectedOutput));
        }
    }
}
