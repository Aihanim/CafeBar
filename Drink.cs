using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class Drink
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        public Drink(string name, string type, decimal price)
        {
            Name = name;
            Type = type;
            Price = price;
        }

        public decimal GetCost(int quantity)
        {
            return Price * quantity;
        }
    }
}
