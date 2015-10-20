using System;
using System.Collections.Generic;
using System.Configuration;
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
            //if (!IsValidDishes(inputDishes))
            //{
            //    Console.WriteLine("Sorry, I didn't get that.");
            //    Console.WriteLine("Please enter a comma-delimited list of numbers to tell me what dishes you would like.");
            //    Console.WriteLine("1 - entree");
            //    Console.WriteLine("2 - side");
            //    Console.WriteLine("3 - drink");
            //    Console.WriteLine("4 - dessert");
            //    Console.WriteLine();
            //    Console.WriteLine("For example, enter");
            //    Console.WriteLine("1,2");
            //    Console.WriteLine("if you would like and entree and a side.");

            //    inputDishes = Console.ReadLine();

            //    if (!IsValidDishes(inputDishes))
            //    {
            //        Console.WriteLine("Seriously?");
            //        return;
            //    }
            //}

            var output = GetOutput(timeOfDay, inputDishes);

            Console.WriteLine(output);
            Console.ReadLine();
        }

        private static string GetOutput(TimeOfDay timeOfDay, string inputDishes)
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

        //private static bool IsValidDishes(string inputDishes)
        //{
        //    var dishes = inputDishes.Split(',');
        //    foreach (var dish in dishes)
        //    {
        //        var trimmedDish = dish.Trim();
        //        int j;
        //        if (!int.TryParse(trimmedDish, out j))
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}
