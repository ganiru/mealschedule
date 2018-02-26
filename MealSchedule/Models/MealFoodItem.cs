using System;
using SQLite;

namespace MealSchedule.Models
{
    /// <summary>
    /// Linking food items to each meal
    /// </summary>
    [Table(nameof(MealFoodItem))]
    public class MealFoodItem
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        [NotNull]
        public string MealId { get; set; }

        [NotNull]
        public string FoodItemId { get; set; }
    }
}