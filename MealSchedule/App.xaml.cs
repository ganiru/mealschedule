using FreshMvvm;
using MealSchedule;
using MealSchedule.PageModels;
using Xamarin.Forms;

namespace MealSchedule
{
    public static class NavigationContainerNames
    {
        public const string AuthenticationContainer = "AuthenticationContainer";
        public const string MainContainer = "MainContainer";
    }


    public partial class App : Application
    {
        private FreshTabbedNavigationContainer tabbedContainer;
        private FreshNavigationContainer loginContainer;

        public App()
        {
            InitializeComponent();

            SetupLoginNav();
            SetupTabbedNav();

            //MainPage = loginContainer; 
            MainPage = tabbedContainer;

        }

        /*
        public void FreshTabbedNavigationContainer(string navigationServiceName)
        {
            NavigationServiceName = navigationServiceName;
            RegisterNavigation();
        }

        protected void RegisterNavigation()
        {
            FreshIOC.Container.Register<IFreshNavigationService>(this, NavigationServiceName);
        }

*/
        void SetupTabbedNav()
        {
            tabbedContainer = new FreshTabbedNavigationContainer();
            tabbedContainer.AddTab<NowPageModel>("Now",null);
            tabbedContainer.AddTab<DayPageModel>("Today", null);
            tabbedContainer.AddTab<WeekPageModel>("Week", null);

   //         tabbedContainer.BarBackgroundColor=Color.Black;
   //         tabbedContainer.BarTextColor = Color.White;
        }


        void SetupLoginNav()
        {
            // Login navigation & stuff https://github.com/rid00z/FreshMvvm
            var loginPage = FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
            loginContainer = new FreshNavigationContainer(loginPage, NavigationContainerNames.AuthenticationContainer);
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
