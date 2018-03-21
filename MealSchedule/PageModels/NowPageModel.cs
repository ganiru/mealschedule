using System;
using FreshMvvm;
using Xamarin.Forms;

namespace MealSchedule.PageModels
{
    public class NowPageModel : FreshBasePageModel
    {
        public string Day { get => DateTime.Now.ToString("dddd"); }
        private string _todayBackgroundimg;
        public string MealTime { get => SetMealTime(); }
        public string backgroundIMG { get => _todayBackgroundimg; }
        public string[] FoodItems{ get => _fooditems; }
        public string[] _fooditems;
        public int FoodItemsCount { get => _fooditems.Length * 50; }



        public NowPageModel()
        {
            SetMealTime();

            _fooditems = new string[]{
                "Bread","Eggs","Coffee","Toast","Bacon","Beans"
            };
        }

        public string SetMealTime()
        {
            string mealtime = "";

            // meal time
            if (DateTime.Now.Hour > 0 && DateTime.Now.Hour < 9)
            {
                mealtime = "Breakfast";
                _todayBackgroundimg = "morningcoffee.jpg";
            }
            else if (DateTime.Now.Hour >= 9 && DateTime.Now.Hour < 11)
            {
                mealtime = "Morning snack";
                _todayBackgroundimg = "morningcoffee.jpg";
            }
            else if (DateTime.Now.Hour >= 11 && DateTime.Now.Hour < 14)
            {
                mealtime = "Lunch";
                _todayBackgroundimg = "jollof.jpg";
            }
            else if (DateTime.Now.Hour >= 14 && DateTime.Now.Hour < 17)
            {
                mealtime = "Afternoon snack";
                _todayBackgroundimg = "morningcoffee.jpg";
            }
            else if (DateTime.Now.Hour >= 17)
            {
                mealtime = "Dinner";
                _todayBackgroundimg = "fish_beans_plantain.jpg";
            }

            _fooditems = new string[]{
                "Bread","Eggs","Coffee","Toast","Bacon"
            };

            return mealtime;
        }
    }
}
