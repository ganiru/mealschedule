using FreshMvvm;
using MealSchedule;
using MealSchedule.PageModels;
using Xamarin.Forms;

namespace MealSchedule
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var page = FreshPageModelResolver.ResolvePageModel<FoodItemListPageModel>();
            var navContainer = new FreshNavigationContainer(page);
            MainPage = navContainer; //new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
