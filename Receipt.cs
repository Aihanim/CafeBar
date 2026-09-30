using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp4;
using static WindowsFormsApp4.Form1;

public class Receipt
{
    public string Create(Order order)
    {
        string folder = Path.Combine(
            Application.StartupPath,
            "Чеки"
        );

        Directory.CreateDirectory(folder);

        string orderNumber =
            DateTime.Now.ToString("yyyyMMddHHmmss");

        string fileName =
            "Чек_" + orderNumber + ".txt";

        string filePath =
            Path.Combine(folder, fileName);

        StringBuilder receipt =
            new StringBuilder();

        receipt.AppendLine(
            "========================================"
        );

        receipt.AppendLine(" КАФЕ-БАР");

        receipt.AppendLine(
            "========================================"
        );

        receipt.AppendLine();

        receipt.AppendLine(
            "Номер заказа: " + orderNumber
        );

        receipt.AppendLine(
            "Дата: " +
            DateTime.Now.ToString("dd.MM.yyyy")
        );

        receipt.AppendLine(
            "Время: " +
            DateTime.Now.ToString("HH:mm:ss")
        );

        receipt.AppendLine(
            "----------------------------------------"
        );

        foreach (OrderItem item in order.Items)
        {
            receipt.AppendLine(item.Drink.Name);

            receipt.AppendLine(
                "Цена: " + item.Drink.Price +
                " ₸ Количество: " +
                item.Quantity
            );

            receipt.AppendLine(
                "Сумма: " + item.Total + " ₸"
            );

            receipt.AppendLine(
                "----------------------------------------"
            );
        }

        receipt.AppendLine();

        receipt.AppendLine(
            "ИТОГО: " + order.GetTotal() + " ₸"
        );

        receipt.AppendLine();

        receipt.AppendLine(
            " Спасибо за заказ!"
        );

        receipt.AppendLine(
            "========================================"
        );

        File.WriteAllText(
            filePath,
            receipt.ToString(),
            Encoding.UTF8
        );

        return filePath;
    }
}