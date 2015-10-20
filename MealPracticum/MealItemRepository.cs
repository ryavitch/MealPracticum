using System;

namespace MealPracticum
{

    public class MealItemRepository
    {
        private static MealItem[] morningMealItems = {MealItem.eggs, MealItem.toast, MealItem.coffee};
        private static MealItem[] nightMealItems = {MealItem.steak, MealItem.potato, MealItem.wine, MealItem.cake};

        public MealItem GetMealItems(TimeOfDay timeOfDay, short dishType)
        {
            var dishTypeIndex = dishType - 1;
            
            switch (timeOfDay.Time)
            {
                case TimeOfDayEnum.morning:
                    return morningMealItems[dishTypeIndex];
                case TimeOfDayEnum.night:
                    return nightMealItems[dishTypeIndex];
                default:
                    throw new ArgumentException();
            }
        }
    }
}
