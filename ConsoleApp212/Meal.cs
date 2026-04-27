using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp212
{
    class Meal
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Meal(string name)
        {
            Name = name;
        }

        public Meal(string name, int price)
        {
            if (price > 0)
            {
                Name = name;
                Price = price;
            }
            else
            {
                Name = name;
                Price = 1;
            }
        }
    }

}
