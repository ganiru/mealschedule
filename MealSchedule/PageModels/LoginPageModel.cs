using System;
using FreshMvvm;
using MealSchedule.PageModels;
using Xamarin.Forms;

namespace MealSchedule.PageModels
{
    public class LoginPageModel : FreshBasePageModel
    {
        public LoginPageModel()
        {
            System.Diagnostics.Debug.WriteLine("Hello LoginPageModel()");
            //ContinueAsGuestCommand = new Command(ContinueAsGuest);
        }

        public Command ContinueAsGuestCommand {
            get
            {
                return new Command(async () => { 
                    try
                    {
                        CoreMethods.SwitchOutRootNavigation(NavigationContainerNames.MainContainer);
                        await CoreMethods.PushPageModel<FoodItemListPageModel>();

                    }
                    catch(Exception e){System.Diagnostics.Debug.WriteLine("Error in loginpagemodel: ", e.Message);}

                });
            }
        }

        public void ContinueAsGuest()
        {
            /*
            var fooditemlistpage = FreshPageModelResolver.ResolvePageModel<FoodItemListPageModel>();
            var nav = new FreshNavigationContainer(fooditemlistpage);
            await CoreMethods.PushPageModel<FoodItemListPageModel>();


            System.Diagnostics.Debug.WriteLine("Navigate to the main page");
            CoreMethods.SwitchOutRootNavigation(NavigationContainerNames.MainContainer);
            var page = FreshPageModelResolver.ResolvePageModel<FoodItemListPageModel>();
            var navContainer = new FreshTabbedNavigationContainer(page);


            System.Diagnostics.Debug.WriteLine("Done navigating");
            */
        }
    }
}
