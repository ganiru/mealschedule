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

        public string StatusMessage { get; set; }

        public Repository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<FoodItem>().Wait();
            //conn.CreateTableAsync<Meal>().Wait();
            //conn.CreateTableAsync<MealFoodItem>().Wait();
            System.Diagnostics.Debug.WriteLine("Repository() def");
        }

        /// <summary>
        /// Creates the food item.
        /// </summary>
        /// <returns>The food item.</returns>
        /// <param name="item">Item.</param>
        public async Task CreateFoodItem(FoodItem item)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(item.Name))   throw new Exception("Name is required");

                // Insert/update Food item
                var result = await conn.InsertOrReplaceAsync(item).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} record(s) added [Food item: {item.Name}])";
            }
            catch(Exception ex)
            {
                StatusMessage = $"Unable to create food item {item.Name}. Error: {ex.Message}";
            }
        }

        /// <summary>
        /// Gets all food items.
        /// </summary>
        /// <returns>The food items.</returns>
        public Task<List<FoodItem>> GetAllFoodItems()
        {
            System.Diagnostics.Debug.WriteLine("Get all food stuff");
            // Return all the meals
            return conn.Table<FoodItem>().ToListAsync();
        }

        /// <summary>
        /// Creates the meal.
        /// </summary>
        /// <returns>The meal.</returns>
        /// <param name="meal">Meal.</param>
        public async Task CreateMeal(Meal meal)//TODO add MealFoodItems records
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(meal.Day))
                    throw new Exception("The day of the week is required");
                else if (string.IsNullOrWhiteSpace(meal.Type))
                    throw new Exception("The meal type is required");

                // Insert/update the meal
                var result = await conn.InsertOrReplaceAsync(meal).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} meal record(s) added [Meal added: {meal.Day} {meal.Type}])";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Unable to create meal: {meal.Day} {meal.Type}. Error: {ex.Message}";
            }
        }

        /// <summary>
        /// Gets all meals.
        /// </summary>
        /// <returns>The meals.</returns>
        public Task<List<Meal>> GetAllMeals()
        {
            // Return all the meals
            return conn.Table<Meal>().ToListAsync();
        }


    }
}
