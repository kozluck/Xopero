using System;
using System.Collections.Generic;
using System.Windows;

namespace ShopManager
{

    public partial class editWindow : Window
    {

        private DBManager dbManager = new DBManager(new SQLite());
        private Item item;

        public editWindow(int id)
        {
            InitializeComponent();
            List<Item> items = dbManager.GetItems();
            item = items.Find(x => x.Id == id);
            ItemName.Text = item.Name;
            ItemPrice.Text = item.Price.ToString();
            ItemQuantity.Text = item.Quantity.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                item.Name = ItemName.Text;
                item.Quantity = int.Parse(ItemQuantity.Text);
                item.Price = double.Parse(ItemPrice.Text);
                dbManager.editItem(item);
                this.Hide();
                MainWindow main = new();
                main.Show();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error", "Use numbers in fields with quantity and price. Try again!");
            }

        }
    }
}
