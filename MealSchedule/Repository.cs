using System;
using MealSchedule.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MealSchedule
{
    public class Repository
    {
        private readonly SQLiteAsyncConnection conn;
 //       private readonly SQLiteConnection conn2;

        public string StatusMessage { get; set; }

        public Repository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<FoodItem>().Wait();
            //conn.CreateTableAsync<Meal>().Wait();
            //conn.CreateTableAsync<MealFoodItem>().Wait();

            //conn2 = new SQLiteConnection(dbPath);
            //conn2.CreateTable<FoodItem>();
            //System.Diagnostics.Debug.WriteLine("Repository() def");
        }

        public async Task CreateFoodItem(FoodItem item)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(item.Name)) throw new Exception("Name is required");

                // Insert/update Food item
                var result = await conn.InsertOrReplaceAsync(item).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} record(s) added [Food item: {item.Name}])";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Unable to create food item {item.Name}. Error: {ex.Message}";
            }
        }


        public async Task DeleteFoodItem(FoodItem item)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(item.Name)) throw new Exception("Name is required");

                // Insert/update Food item
                var result = await conn.DeleteAsync(item).ConfigureAwait(continueOnCapturedContext: false);
                System.Diagnostics.Debug.WriteLine($"{item.Name} has been deleted])");
                StatusMessage = $"{item.Name} has been deleted])";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Unable to create food item {item.Name}. Error: {ex.Message}";
            }
        }


        public Task<List<FoodItem>> GetAllFoodItems()
        {
            System.Diagnostics.Debug.WriteLine("Get all food stuff");
            // Return all the meals
            return conn.Table<FoodItem>().ToListAsync();
        }


        public List<FoodItem> GetTheFoodItems()// TODO Not used
        {
            System.Diagnostics.Debug.WriteLine("Get all food stuff");
            // Return all the meals
            List<FoodItem> thelist = new List<FoodItem>();
            /*
            foreach (var fi in conn2.Table<FoodItem>())
            {
                thelist.Add(fi);
            }
            */
            return thelist;
        }

        /*
        public async Task CreateMeal(MealInfo meal)//TODO add MealFoodItems records
        {
            try
            {
                // Validation
               // if (string.IsNullOrWhiteSpace(meal.Day))
                //    throw new Exception("The day of the week is required");
                //else if (string.IsNullOrWhiteSpace(meal.Type))
               //     throw new Exception("The meal type is required");

                // Insert/update the meal
                var result = await conn.InsertOrReplaceAsync(meal).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} meal record(s) added [Meal added)";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Unable to create meal. Error: {ex.Message}";
            }
        }
        */

        public Task<List<MealInfo>> GetAllMeals()
        {
            // Return all the meals
            return conn.Table<MealInfo>().ToListAsync();
        }


        /*
         * MealDayType
         * */

        public async Task CreateMealDayType(MealDayTypes mealdaytype)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(mealdaytype.Day)) throw new Exception("Day is required");
                if (string.IsNullOrWhiteSpace(mealdaytype.Type)) throw new Exception("Type is required");
                //if (mealdaytype.MealInfoId? == null) throw new Exception("Day is required");

                // Insert/update Food item
                var result = await conn.InsertOrReplaceAsync(mealdaytype).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} record(s) added [MealDayType: {mealdaytype.Day} - {mealdaytype.Type}])";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Unable to create MealDayType. Error: {ex.Message}";
            }
        }


        public async Task DeleteMealDayType(MealDayTypes mealdaytype)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(mealdaytype.Day)) throw new Exception("Day is required");
                if (string.IsNullOrWhiteSpace(mealdaytype.Type)) throw new Exception("Type is required");

                // Insert/update Food item
                var result = await conn.DeleteAsync(mealdaytype).ConfigureAwait(continueOnCapturedContext: false);
                System.Diagnostics.Debug.WriteLine($"{mealdaytype.Day} - {mealdaytype.Type} has been deleted])");
                StatusMessage = $"{mealdaytype.Day} - {mealdaytype.Type}  has been deleted])";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Unable to delete MealDayType {mealdaytype.Day} - {mealdaytype.Type} . Error: {ex.Message}";
            }
        }


        /*
         * MealInfo
         * */
        public async Task CreateMealInfo(MealInfo mealinfo)
        {
            try
            {
                var result = await conn.InsertOrReplaceAsync(mealinfo).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} record(s) added [mealinfo: {mealinfo.Id}])";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Unable to create MealInfo. Error: {ex.Message}";
            }
        }


        public async Task DeleteMealInfo(MealInfo mealinfo)
        {
            try
            {
                var result = await conn.DeleteAsync(mealinfo).ConfigureAwait(continueOnCapturedContext: false);
                System.Diagnostics.Debug.WriteLine($"{mealinfo.Id} has been deleted])");
                StatusMessage = $"{mealinfo.Id} has been deleted])";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Unable to delete MealInfo {mealinfo.Id} . Error: {ex.Message}";
            }
        }


        /*
         * MealItems
         * */
        public async Task CreateMealItems(MealItems mealitems)
        {
            try
            {
                var result = await conn.InsertOrReplaceAsync(mealitems).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} record(s) added [mealItems: {mealitems.Id}])";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Unable to create MealItems. Error: {ex.Message}";
            }
        }


        public async Task DeleteMealItems(MealItems mealitems)
        {
            try
            {
                var result = await conn.DeleteAsync(mealitems).ConfigureAwait(continueOnCapturedContext: false);
                System.Diagnostics.Debug.WriteLine($"{mealitems.FoodItemId} has been deleted])");
                StatusMessage = $"{mealitems.FoodItemId} has been deleted])";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Unable to delete MealItems {mealitems.FoodItemId} . Error: {ex.Message}";
            }
        }
    }
}
