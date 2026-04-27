using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp212
{
    class Bill
    {
        public string MealName { get; private set; }
        public int Quantity { get; private set; }
        public decimal Total { get; private set; }
        public string OrderedBy { get; private set; }
        public DateTime Date { get; private set; }

        public Bill(string mealName, int quantity, decimal total, string orderedBy)
        {
            MealName = mealName;
            Quantity = quantity;
            Total = total;
            OrderedBy = orderedBy;
            Date = DateTime.Now;
        }
    }
}
