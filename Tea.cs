using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class Tea : Drink
    {
        public string Size { get; set; }

        public Tea(string name, decimal price, string size)
            : base(name, "Чай", price)
        {
            Size = size;
        }
    }
}
