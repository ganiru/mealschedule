using System;
using SQLite;

namespace MealSchedule.Models
{
    /// <summary>
    /// For the individual food items
    /// </summary>
    [Table(nameof(FoodItem))]
    public class FoodItem
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        [NotNull, MaxLength(250)]
        public string Name { get; set; }

        public bool IsValid()
        {
            return (!String.IsNullOrWhiteSpace(Name));
        }
    }
}