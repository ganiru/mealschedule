using Xamarin.Forms;

namespace MealSchedule
{
    public partial class MealSchedulePage : ContentPage
    {
        async void ContinueAsGuest(object sender, System.EventArgs e)
        {
            //    this.DisplayAlert("Continuing as a guest", "You will proceed as a guest. Nothing special here!!", "Cancel");//throw new NotImplementedException();
            await Navigation.PushAsync(new Pages.NowPage());
        }

        public MealSchedulePage()
        {
            //InitializeComponent();
        }
    }
}
