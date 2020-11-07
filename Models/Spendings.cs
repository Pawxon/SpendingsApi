using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingsApi.Models
{
    public class Spendings
    {
        [Key]
        public int idSpendings { get; set; }
        public DateTime Date { get; set; }

        public int CarID { get; set; }

        public int CostID { get; set; }

        public double Price { get; set; }

    }
}
