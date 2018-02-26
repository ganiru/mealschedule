using System;
using FreshMvvm;
using MealSchedule;
using MealSchedule.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace MealSchedule.PageModels
{
    public class FoodItemPageModel : FreshBasePageModel
    {
        // Use IoC to get our repository.
        private Repository _repository = FreshIOC.Container.Resolve<Repository>();

        // Backing data model
        private FoodItem _fooditem;

        /// <summary>
        /// Gets or sets the name of the food item.
        /// </summary>
        /// <value>The name of the food item.</value>
        public string FoodItemName{
            get { return _fooditem.Name; }
            set { _fooditem.Name = value;  RaisePropertyChanged();}
        }


        /// <summary>
        /// Called when the age is navigated to
        /// Either use a provided food item, or create a new one if empty
        /// </summary>
        /// <returns>The init.</returns>
        /// <param name="initData">Init data.</param>
        public override void Init(object initData)
        {
            _fooditem = initData as FoodItem;
            if (_fooditem == null) _fooditem = new FoodItem();
            base.Init(initData);
            RaisePropertyChanged(nameof(FoodItemName));
        }

        /// <summary>
        /// Command associated with the save action for the food item.
        /// Persists the contact to the database if the contact is valid.
        /// </summary>
        /// <value>The save command.</value>
        public ICommand SaveCommand
        {
            get {
                return new Command(async () =>
                {
                    if (_fooditem.IsValid())
                    {
                        await _repository.CreateFoodItem(_fooditem);
                        await CoreMethods.PopPageModel(_fooditem);
                    }
                });
            }
        }
    }
}
