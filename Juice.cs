using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    
    public class Juice : Drink
    {
        public string Volume { get; set; }

        public Juice(string name, decimal price, string volume)
            : base(name, "Сок", price)
        {
            Volume = volume;
        }
    }
}
