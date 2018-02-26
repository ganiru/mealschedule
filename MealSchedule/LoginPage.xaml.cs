using System;
using System.Collections.Generic;
using FreshMvvm;
using MealSchedule.PageModels;
using Xamarin.Forms;

namespace MealSchedule
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void ContinueAsGuest(object sender, System.EventArgs e)
        {
            //    this.DisplayAlert("Continuing as a guest", "You will proceed as a guest. Nothing special here!!", "Cancel");//throw new NotImplementedException();
            var page = FreshPageModelResolver.ResolvePageModel<FoodItemListPageModel>();
            var navContainer = new FreshNavigationContainer(page);

            await Navigation.PushAsync(new Pages.FoodItemListPage());
        }
    }
}
