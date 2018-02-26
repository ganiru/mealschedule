using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MealSchedule
{
    public partial class RightNowPage : ContentPage
    {
        public RightNowPage()
        {
            InitializeComponent();

            // Current day
            lblDay.Text = DateTime.Now.ToString("dddd"); //String.Format("{dddd}", DateTime.Now);
            // The list of food stuff
            String[] lstFoodItems = new string[]{
                "Rice",
                "Beans",
                "Stew",
                "Chicken"
            };

            Label[] arr = new Label[4];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Label() { Text = lstFoodItems[i], VerticalOptions=LayoutOptions.Center };
                slLayout.Children.Add(arr[i]);

            }
        }
    }
}
