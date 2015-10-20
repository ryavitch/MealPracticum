using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPracticum
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the only meal planner you'll ever need!");

            Console.WriteLine("Please enter the time of day. You may enter morning or night.");
            var inputTimeOfDay = Console.ReadLine();
            var timeOfDay = new TimeOfDay(inputTimeOfDay);
            if (!timeOfDay.IsValid)
            {
                Console.WriteLine("error");
                return;
            }

            Console.WriteLine();

            Console.WriteLine("What dishes would you like?");
            var inputDishes = Console.ReadLine();

            var output = GetOutput(timeOfDay, inputDishes);

            Console.WriteLine(output);
            Console.ReadLine();
        }

        public static string GetOutput(TimeOfDay timeOfDay, string inputDishes)
        {
            var meal = new Meal(timeOfDay);
            List<short> dishIndexes;
            if (!Meal.TryParseMealItems(inputDishes, out dishIndexes))
            {
                return "Sorry, I didn't get that.";
            }

            string dishesOutput = string.Empty;
            foreach (var dishIndex in dishIndexes)
            {
                meal.AddMealItem(dishIndex);

                if (meal.IsValid)
                {
                    dishesOutput = GetOutputFromMeal(meal);
                }
                else
                {
                    if (!string.IsNullOrEmpty(dishesOutput))
                    {
                        dishesOutput += ", ";
                    }
                    dishesOutput += "error";
                    break;
                }
            }

            return dishesOutput;
        }

        private static string GetOutputFromMeal(Meal meal)
        {
            string output = string.Empty;
            var sortedMealItems = meal.GetSortedMealItems();
            var groupedMealItems = sortedMealItems.GroupBy(mealItem => mealItem);

            foreach (var mealItemsGroup in groupedMealItems)
            {
                if (!string.IsNullOrEmpty(output))
                {
                    output += ", ";
                }
                var mealItemString = mealItemsGroup.Key + (mealItemsGroup.Count() > 1 ? "(x" + mealItemsGroup.Count() + ")" : string.Empty);
                output += mealItemString;
            }

            return output;
        }
    }
}
