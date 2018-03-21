using System;
using SQLite;

namespace MealSchedule.Models
{
    /// <summary>
    /// Linking food items to each meal
    /// </summary>
    [Table(nameof(MealItems))]
    public class MealItems
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        [NotNull]
        public int MealInfoId { get; set; }

        [NotNull]
        public int FoodItemId { get; set; }

        public bool IsValid()
        {
            return ((MealInfoId > 0) && (FoodItemId > 0));
        }
    }
}