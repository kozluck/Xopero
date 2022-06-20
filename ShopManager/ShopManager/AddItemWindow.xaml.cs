using System;
using System.Windows;

namespace ShopManager
{
    public partial class AddItemWindow : Window
    {
        DBManager dbManager = new (new SQLite());

        public AddItemWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Item item = new();
                item.Id = dbManager.GetNewId();
                item.Name = ItemName.Text;
                item.Quantity = int.Parse(ItemQuantity.Text);
                item.Price = double.Parse(ItemPrice.Text);
                dbManager.addItem(item);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error", "Use numbers in fields with quantity and price. Try again!");
            }

            MainWindow window = new MainWindow();
            window.Show();
            this.Hide();
        }
    }
}
