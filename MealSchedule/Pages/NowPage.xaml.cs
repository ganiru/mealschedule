using System;
using System.Collections.Generic;
using FreshMvvm;
using MealSchedule.PageModels;
using Xamarin.Forms;

namespace MealSchedule.Pages
{
    public partial class NowPage : FreshBaseContentPage
    {
        public string[] _theFoodItems;
        public string[] todaysFoodItems { get => _theFoodItems; }

        public NowPage()
        {
            InitializeComponent();
            BindingContext = new NowPageModel();

            //var semitransparentColor = new Color(0, 0, 0, 0.5);
            //layoutFoodItems.BackgroundColor = semitransparentColor;
            /*
            NowPageModel n = new NowPageModel();
            for (var i = 0; i < n.FoodItems.Length; i++)
            {
                layoutFoodItems.Children.Add(new Label() { Text = n.FoodItems[i] });
            }
*/
        }
    }
}
