using System;
using SQLite;

namespace MealSchedule.Models
{
    [Table(nameof(MealItems))]
    public class MealDayTypes
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }


        [NotNull]
        public int MealInfoId { get; set; }


        [NotNull, MaxLength(4)]
        public string Day { get; set; }


        [NotNull, MaxLength(2)]
        public string Type { get; set; }


        public bool IsValid()
        {
            return ((MealInfoId > 0) && (!String.IsNullOrEmpty(Day)) && (!String.IsNullOrEmpty(Type)));
        }

        public MealDayTypes()
        {
        }
    }
}
