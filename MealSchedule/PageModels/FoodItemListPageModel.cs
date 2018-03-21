using FreshMvvm;
using MealSchedule;
using MealSchedule.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MealSchedule.PageModels
{
    public class FoodItemListPageModel : FreshBasePageModel
    {
        private readonly Repository _repository = FreshIOC.Container.Resolve<Repository>();
        private FoodItem _selectedFoodItem = null;

        /// <summary>
        /// Collection for binding to the pages food item list view
        /// </summary>
        /// <value>The fooditems.</value>
        public ObservableCollection<FoodItem> Fooditems { get; private set; }
        public List<FoodItem> FoodItemList { get; private set; }
        public string HowManyItems { get => Fooditems.Count().ToString(); set { HowManyItems = value; } }



        /// <summary>
        /// Used to bind with the list view's SelectedItem property.
        /// Calls the EditContactCommand to start the editing.
        /// </summary>
        /// <value>The selected food item.</value>
        public FoodItem SelectedFoodItem
        {
            get { return _selectedFoodItem; }
            set {
                _selectedFoodItem = value;
                if (value != null) EditFoodItemCommand.Execute(value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the food items.
        /// </summary>
        public FoodItemListPageModel()
        {
            Fooditems = new ObservableCollection<FoodItem>();
            FoodItemList = new List<FoodItem>();
        }


        /// <summary>
        /// Called whenever the page is navigated to.
        /// Here we are ignoring the init data and just loading the contacts.
        /// </summary>
        public override void Init(object initData)
        {
            LoadFoodItems();
            System.Diagnostics.Debug.WriteLine("Food items loaded. Count: " + Fooditems.Count());

            if (!Fooditems.Any()) CreateSampleData();
        }

        /// <summary>
        /// Called whenever the page is navigated to, but from a pop action.
        /// Here we are just updating the contact list with most recent data.
        /// </summary>
        /// <param name="returnedData"></param>
        public override void ReverseInit(object returnedData)
        {
            LoadFoodItems();
            base.ReverseInit(returnedData);
        }


        /// <summary>
        /// Command associated with the add contact action.
        /// Navigates to the ContactPageModel with no Init object.
        /// </summary>
        public ICommand AddFoodItemCommand
        {
            get
            {
                return new Command(async () => {
                    await CoreMethods.PushPageModel<FoodItemPageModel>();
                });
            }
        }


        /// <summary>
        /// Command associated with the edit food item action.
        /// Navigates to the FoodItemPageModel with the selected food item as the Init object.
        /// </summary>
        /// <value>The edit food item command.</value>
        public ICommand EditFoodItemCommand
        {
            get
            {
                return new Command(async (FoodItem) => {
                    await CoreMethods.PushPageModel<FoodItemPageModel>(FoodItem);
                });
            }
        }




        /// <summary>
        /// Repopulate the collection with updated contacts data.
        /// Note: For simplicity, we wait for the async db call to complete,
        /// recommend making better use of the async potential.
        /// </summary>
        private async void LoadFoodItems()
        {
            Fooditems.Clear();

            Task<List<FoodItem>> getFoodItemsTask = _repository.GetAllFoodItems();
            getFoodItemsTask.Wait();

            foreach (var item in getFoodItemsTask.Result)
            {
                Fooditems.Add(item);
            }

            System.Diagnostics.Debug.WriteLine("Loading food start");
            foreach(var each in await _repository.GetAllFoodItems())
            {
                FoodItemList.Add(each);
                System.Diagnostics.Debug.WriteLine("Add item " + each.Name.ToString());
            }
            System.Diagnostics.Debug.WriteLine("Loading food end");
            HowManyItems = Fooditems.Count().ToString() + " food items";
        }


        /// <summary>
        /// Uses the SQLite Async capability to insert sample data on multiple threads.
        /// </summary>
        private void CreateSampleData()
        {System.Diagnostics.Debug.WriteLine("SAMPLEDATA()");
            var fooditem1 = new FoodItem
            {
                Name = "Rice"
            };

            var fooditem2 = new FoodItem
            {
                Name = "Beans"
            };

            var fooditem3 = new FoodItem
            {
                Name = "Chicken"
            };

            var task1 = _repository.CreateFoodItem(fooditem1);
            var task2 = _repository.CreateFoodItem(fooditem2);
            var task3 = _repository.CreateFoodItem(fooditem3);

            // Don't proceed until all the async inserts are complete.
            var allTasks = Task.WhenAll(task1, task2, task3);
            allTasks.Wait();

            System.Diagnostics.Debug.WriteLine("Sample created");

            LoadFoodItems();
        }
    }
}