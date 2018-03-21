using System;
using System.Collections.Generic;
using MealSchedule.PageModels;
using Xamarin.Forms;

namespace MealSchedule.Pages
{
    public partial class WeekPage : ContentPage
    {
        public WeekPage()
        {
            InitializeComponent();
            BindingContext = new WeekPageModel();

            WeekPageModel wpm = new WeekPageModel();

            // The styles for each meal
            var styleMeal = new Style(typeof(Label))
            {
                Setters = {
                    new Setter { Property = BackgroundColorProperty, Value = Color.White },
                    new Setter { Property = Label.TextColorProperty, Value = Color.Black },
                    new Setter { Property = Label.FontSizeProperty, Value = 9 }
                }
            };

            // The day of the week
            var styleDay = new Style(typeof(Label))
            {
                Setters = {
                    new Setter { Property = BackgroundColorProperty, Value = Color.FromHex ("#000") },
                    new Setter { Property = Label.TextColorProperty, Value = Color.White },
                    new Setter { Property = Label.FontSizeProperty, Value = 9 },
                    new Setter { Property = Label.FontAttributesProperty, Value = FontAttributes.Bold },
                    new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Center },
                    new Setter { Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.Center},
                }
            };

            // The meal types
            var styleMealType = new Style(typeof(Label))
            {
                Setters = {
                    new Setter { Property = BackgroundColorProperty, Value = Color.FromHex ("#eee") },
                    new Setter { Property = Label.TextColorProperty, Value = Color.Black },
                    new Setter { Property = Label.FontSizeProperty, Value = 9 },
                    new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Center },
                    new Setter { Property = Label.VerticalTextAlignmentProperty, Value = TextAlignment.Center},
                    new Setter { Property = Label.FontAttributesProperty, Value = FontAttributes.Bold }
                }
            };


            // Populate the header row
            for (var x = 0; x < wpm.Days.Length; x++)
            {
                grdWeek.Children.Add(new Label { Text = wpm.Days[x], Style = styleDay }, x+1, 0); // The days header row
            }

            // Populate the 1st column of each row with the meal type
            for (var y = 0; y < wpm.MealType.Length; y++) // each row
            {
                grdWeek.Children.Add(new Label { Text = wpm.MealType[y], Style = styleMealType }, 0, y+1);  // The meal type column
            }

            // Populate each meal
            for (var y = 0; y < wpm.MealType.Length; y++) // each row
            {
                for (var x = 0; x < wpm.Days.Length; x++) // each column
                {
                    grdWeek.Children.Add(new Label { Text = wpm.Days[x] + "; " + wpm.MealType[y], Style = styleMeal }, x+1, y+1); // Each meal
                }
            }
        }
    }
}
