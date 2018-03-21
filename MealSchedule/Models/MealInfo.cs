using System;
using SQLite;

namespace MealSchedule.Models
{
    /// <summary>
    /// For each meal
    /// </summary>
    [Table(nameof(MealInfo))]
    public class MealInfo
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        [MaxLength(300)]
        public string Instructions { get; set; }

        [MaxLength(300)]
        public string Picture { get; set; }


        public bool IsValid()
        {
            return true; //(!String.IsNullOrWhiteSpace(Day) && !String.IsNullOrWhiteSpace(Type));
        }
    }
}