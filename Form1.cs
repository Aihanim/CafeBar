using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private List<Drink> drinks = new List<Drink>();
        private Order order = new Order();

        private void CreateDrinks()
        {
            drinks.Add(new Coffee("Эспрессо", 700, "маленький"));
            drinks.Add(new Coffee("Капучино", 1200, "средний"));
            drinks.Add(new Coffee("Латте", 1300, "большой"));

            drinks.Add(new Tea("Черный чай", 600, "средний"));
            drinks.Add(new Tea("Зеленый чай", 650, "средний"));
            drinks.Add(new Tea("Фруктовый чай", 750, "большой"));

            drinks.Add(new Juice("Апельсиновый сок", 900, "300 мл"));
            drinks.Add(new Juice("Яблочный сок", 800, "300 мл"));
            drinks.Add(new Juice("Вишневый сок", 850, "300 мл"));
        }
        public Form1()
        {
            InitializeComponent();
            CreateDrinks();
            comboBox1.Items.Add("Сок");
            comboBox1.Items.Add("Кофе");
            comboBox1.Items.Add("Чай");

            comboBox1.SelectedIndex = 0;
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 20;
            numericUpDown1.Value = 1;
            dataGridView1.ColumnCount = 4;

            dataGridView1.Columns[0].Name = "Напиток";
            dataGridView1.Columns[1].Name = "Цена";
            dataGridView1.Columns[2].Name = "Количество";
            dataGridView1.Columns[3].Name = "Сумма";

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            if (comboBox1.SelectedItem == null)
            {
                return;
            }

            string selectedType = comboBox1.SelectedItem.ToString();

            foreach (Drink drink in drinks)
            {
                if (drink.Type == selectedType)
                {
                    comboBox2.Items.Add(drink.Name);
                }
            }

            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }

        }
        private Drink GetSelectedDrink()
        {
            if (comboBox1.SelectedItem == null ||
                comboBox2.SelectedItem == null)
            {
                return null;
            }

            string selectedType = comboBox1.SelectedItem.ToString();
            string selectedName = comboBox2.SelectedItem.ToString();

            foreach (Drink drink in drinks)
            {
                if (drink.Type == selectedType &&
                    drink.Name == selectedName)
                {
                    return drink;
                }
            }

            return null;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Drink selectedDrink = GetSelectedDrink();

            if (selectedDrink != null)
            {
                label1.Text =
                    "Цена: " + selectedDrink.Price + " ₸";

                int quantity =
                    (int)numericUpDown1.Value;

                decimal total =
                    selectedDrink.Price * quantity;

                label2.Text =
                    "Стоимость: " + total + " ₸";
            }
        }
       

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Drink selectedDrink = GetSelectedDrink();

            if (selectedDrink != null)
            {
                int quantity =
                    (int)numericUpDown1.Value;

                decimal total =
                    selectedDrink.Price * quantity;

                label2.Text =
                    "Стоимость: " + total + " ₸";
            }
        }
        public class OrderItem
        {
            public Drink Drink { get; set; }

            public int Quantity { get; set; }

            public decimal Total
            {
                get
                {
                    return Drink.Price * Quantity;
                }
            }

            public OrderItem(Drink drink, int quantity)
            {
                Drink = drink;
                Quantity = quantity;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Drink selectedDrink = GetSelectedDrink();

            if (selectedDrink == null)
            {
                MessageBox.Show("Выберите напиток!");
                return;
            }

            int quantity =
                (int)numericUpDown1.Value;

            order.AddItem(selectedDrink, quantity);

            OrderItem item =
                order.Items[order.Items.Count - 1];

            dataGridView1.Rows.Add(
                item.Drink.Name,
                item.Drink.Price + " ₸",
                item.Quantity,
                item.Total + " ₸"

            );

            UpdateTotal();
        }
            private void UpdateTotal()
        {
            decimal total = order.GetTotal();

            label4.Text =
                "Итого: " + total + " ₸";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Выберите позицию для удаления!"
                );

                return;
            }

            int rowIndex =
                dataGridView1.SelectedRows[0].Index;

            order.RemoveItem(rowIndex);

            dataGridView1.Rows.RemoveAt(rowIndex);

            UpdateTotal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (order.IsEmpty())
            {
                MessageBox.Show("Заказ уже пуст!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Очистить весь заказ?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                order.Clear();
                dataGridView1.Rows.Clear();
                UpdateTotal();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (order.IsEmpty())
            {
                MessageBox.Show(
                    "Заказ пуст. Добавьте хотя бы один напиток.",
                    "Создание чека",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Receipt receipt = new Receipt();

            string filePath =
                receipt.Create(order);

            MessageBox.Show(
                "Чек успешно создан!\n\n" +
                "Файл сохранен:\n" +
                filePath,
                "Чек создан",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string folder = Path.Combine(
                Application.StartupPath,
                "Чеки"
            );

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            System.Diagnostics.Process.Start(
                "explorer.exe",
                folder
            );
        }
    }
    }


 