using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FreshMvvm;
using MealSchedule.PageModels;

namespace MealSchedule.Pages
{
    public partial class FoodItemListPage : FreshBaseContentPage
    {

        public FoodItemListPage()
        {
            InitializeComponent();
            BindingContext = new FoodItemListPageModel();
        }
    }
}
