using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPracticum
{
    public class Meal
    {
        private static readonly List<MealItem> MultiplesAllowed = new List<MealItem>()
        {
            MealItem.coffee,
            MealItem.potato
        };
        private List<MealItem> _mealItems = new List<MealItem>();
        private TimeOfDay _timeOfDay;
        private bool _isValidIndexes = true;

        public bool IsValid
        {
            get
            {
                if (!_isValidIndexes)
                {
                    return false;
                }
                var groupedMealItems = _mealItems.GroupBy(mealItem => mealItem);
                var multipleMealItems = groupedMealItems.Where(grouping => grouping.Count() > 1);

                if (
                    multipleMealItems.Select(groupingWithMultiples => groupingWithMultiples.Key)
                        .All(mealItem => MultiplesAllowed.Contains(mealItem)))
                {
                    return true;
                }
                return false;
            }
        }

        public static bool TryParseMealItems(string inputMealItems, out List<short> parsedMealItems)
        {
            try
            {
                parsedMealItems = inputMealItems.Split(',').Select(inputDish => short.Parse(inputDish.Trim())).ToList();
            }
            catch (FormatException e)
            {
                parsedMealItems = null;
                return false;
            }
            return true;
        }

        public Meal(TimeOfDay timeOfDay)
        {
            _timeOfDay = timeOfDay;
        }

        public void AddMealItem(short mealItemIndex)
        {
            try
            {
                MealItem mealItem = new MealItemRepository().GetMealItems(_timeOfDay, mealItemIndex);
                _mealItems.Add(mealItem);
            }
            catch (IndexOutOfRangeException e)
            {
                _isValidIndexes = false;
            }
        }

        public IOrderedEnumerable<MealItem> GetSortedMealItems()
        {
            return _mealItems.OrderBy(mealItem => (int) mealItem);
        }
    }
}
