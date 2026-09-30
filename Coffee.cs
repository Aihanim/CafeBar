using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class Coffee : Drink
    {
        public string Size { get; set; }

        public Coffee(string name, decimal price, string size)
            : base(name, "Кофе", price)
        {
            Size = size;
        }
    }
}
