using System;

namespace MealPracticum
{

    public class MealItemRepository
    {
        private static readonly MealItem[] MorningMealItems = {MealItem.eggs, MealItem.toast, MealItem.coffee};
        private static readonly MealItem[] NightMealItems = {MealItem.steak, MealItem.potato, MealItem.wine, MealItem.cake};

        public MealItem GetMealItems(TimeOfDay timeOfDay, short dishType)
        {
            var dishTypeIndex = dishType - 1;
            
            switch (timeOfDay.Time)
            {
                case TimeOfDayEnum.morning:
                    return MorningMealItems[dishTypeIndex];
                case TimeOfDayEnum.night:
                    return NightMealItems[dishTypeIndex];
                default:
                    throw new ArgumentException();
            }
        }
    }
}
