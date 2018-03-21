using System;
using FreshMvvm;
using MealSchedule.PageModels;
using Xamarin.Forms;
using MealSchedule;

namespace MealSchedule.PageModels
{
    public class WeekPageModel : FreshBasePageModel
    {
        public string[] Days { get => _days; }
        public string[] MealType { get => _mealType; }
        private string[] _days;
        private string[] _mealType;


        public WeekPageModel()
        {
            //foreach (var n in Settings.Days)
            //    System.Diagnostics.Debug.WriteLine(n);

            //System.Diagnostics.Debug.WriteLine("Meal types");

            //foreach (var n in Settings.MealTypes)
            //    System.Diagnostics.Debug.WriteLine(n);

            //string[] thedays = Settings.Days;
            //string thedays = ",Sun,Mon,Tue,Wed,Thur,Fri,Sat";
            _days = Settings.Days;// thedays.Split(',');


            //string thetimes = ",Breakfast,Morning Snacks,Lunch,Afternoon Snacks,Dinner";
            _mealType = Settings.MealTypes;// thetimes.Split(',');
        }


    }
}
