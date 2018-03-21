using System;
using System.Collections.Generic;
using Xamarin.Forms;

using FreshMvvm;
using MealSchedule.PageModels;

namespace MealSchedule.Pages
{
    public partial class LoginPage : FreshBaseContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageModel();
        }
    }
}
