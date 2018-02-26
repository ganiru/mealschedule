using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using FreshMvvm;
using MealSchedule;

namespace MealSchedule.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            var repository = new Repository(FileAccessHelper.GetLocalFilePath("meals.db3"));
            FreshIOC.Container.Register(repository);

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
