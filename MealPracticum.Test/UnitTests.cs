using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MealPracticum.Test
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestIsValidTimeOfDay()
        {
            string lowerCaseTimeOfDayInput = "morning";
            var lowerCaseTimeOfDay = new TimeOfDay(lowerCaseTimeOfDayInput);

            Assert.IsNotNull(lowerCaseTimeOfDay);
            Assert.IsTrue(lowerCaseTimeOfDay.IsValid);

            string upperCaseTimeOfDayInput = "MORNING";
            var upperCaseTimeOfDay = new TimeOfDay(upperCaseTimeOfDayInput);

            Assert.IsNotNull(upperCaseTimeOfDay);
            Assert.IsTrue(upperCaseTimeOfDay.IsValid);

            string invalidTimeOfDayInput = "mroning";
            var invalidCaseTimeOfDay = new TimeOfDay(invalidTimeOfDayInput);

            Assert.IsNotNull(invalidCaseTimeOfDay);
            Assert.IsFalse(invalidCaseTimeOfDay.IsValid);
        }

        [TestMethod]
        public void TestMealInput()
        {
            string input = "1,asdf";
            List<short> output;
            var isValid = Meal.TryParseMealItems(input, out output);

            Assert.IsFalse(isValid);

            string validInput = "1,2";
            var validIsValid = Meal.TryParseMealItems(validInput, out output);

            Assert.IsTrue(validIsValid);
        }

        [TestMethod]
        public void TestMealMultiples()
        {
            var meal = new Meal(new TimeOfDay("morning"));
            meal.AddMealItem(1);
            Assert.IsTrue(meal.IsValid);
            meal.AddMealItem(1);
            Assert.IsFalse(meal.IsValid);

            var meal2 = new Meal(new TimeOfDay("night"));
            meal2.AddMealItem(3);
            Assert.IsTrue(meal2.IsValid);
            meal2.AddMealItem(3);
            Assert.IsFalse(meal2.IsValid);

            var meal3 = new Meal(new TimeOfDay("morning"));
            meal3.AddMealItem(3);
            Assert.IsTrue(meal3.IsValid);
            meal3.AddMealItem(3);
            Assert.IsTrue(meal3.IsValid);
        }
    }
}
