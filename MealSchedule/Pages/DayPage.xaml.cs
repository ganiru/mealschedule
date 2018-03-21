using System;
using System.Collections.Generic;
using MealSchedule.PageModels;
using Xamarin.Forms;
using FreshMvvm;

namespace MealSchedule.Pages
{
    public partial class DayPage : FreshBaseContentPage
    {
        public DayPage()
        {
            InitializeComponent();
            BindingContext = new DayPageModel();

            var semitransparentColor = new Color(0, 0, 0, 0.5);
            breakfastLayout.BackgroundColor = semitransparentColor;
            lunchLayout.BackgroundColor = semitransparentColor;
            dinnerLayout.BackgroundColor = semitransparentColor;
        }
    }
}
