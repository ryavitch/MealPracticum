namespace MealPracticum
{
    public enum TimeOfDayEnum
    {
        morning,
        night
    }

    public class TimeOfDay
    {
        public TimeOfDayEnum? Time { get; set; }
        public bool IsValid { get; private set; }

        public TimeOfDay(string inputTimeOfDay)
        {
            if (string.IsNullOrEmpty(inputTimeOfDay))
            {
                IsValid = false;
                return;
            }
            inputTimeOfDay = inputTimeOfDay.ToLower();

            TimeOfDayEnum time;
            if (TimeOfDayEnum.TryParse(inputTimeOfDay, out time))
            {
                Time = time;
                IsValid = true;
                return;
            }

            IsValid = false;
        }
    }
}