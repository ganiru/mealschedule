using System;
using SQLite;

namespace MealSchedule.Models
{
    /// <summary>
    /// For each meal
    /// </summary>
    [Table(nameof(Meal))]
    public class Meal
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        [NotNull, MaxLength(10)]
        public string Day { get; set; }

        [NotNull, MaxLength(30)]
        public string Type { get; set; }

        [MaxLength(300)]
        public string Instructions { get; set; }

        [MaxLength(300)]
        public string Picture { get; set; }

        public bool IsValid()
        {
            return (!String.IsNullOrWhiteSpace(Day) && !String.IsNullOrWhiteSpace(Type));
        }
    }
}