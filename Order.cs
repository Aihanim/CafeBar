using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp4.Form1;

namespace WindowsFormsApp4
{
    public class Order
    {
        public List<OrderItem> Items { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }

        public void AddItem(Drink drink, int quantity)
        {
            OrderItem item =
                new OrderItem(drink, quantity);

            Items.Add(item);
        }

        public void RemoveItem(int index)
        {
            if (index >= 0 && index < Items.Count)
            {
                Items.RemoveAt(index);
            }
        }

        public void Clear()
        {
            Items.Clear();
        }

        public decimal GetTotal()
        {
            decimal total = 0;

            foreach (OrderItem item in Items)
            {
                total += item.Total;
            }

            return total;
        }

        public bool IsEmpty()
        {
            return Items.Count == 0;
        }
    }
}
