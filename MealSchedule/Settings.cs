using System;
namespace MealSchedule
{
    public class Settings
    {
        public readonly Settings Default = new Settings();
        private static string[] _days = new string[]{
                "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
            };
        private static string[] _mealtypes = new string[]{
                "Breakfast", "Morning snacks", "Lunch", "Afternoon snacks", "Dinner"
            };
        private static string[] _daysAbbr = new string[]{
                "Sun", "Mon", "Tue", "Wed", "Thur", "Fri", "Sat"
            };// use later
        public static string[] Days { get => _days; }
        public static string[] DaysAbbr { get => _daysAbbr; }// TODO Use later
        public static string[] MealTypes { get => _mealtypes; }


        public Settings()
        {

        }

    }
}
