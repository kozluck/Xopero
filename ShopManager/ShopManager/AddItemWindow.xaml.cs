using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShopManager
{
    /// <summary>
    /// Logika interakcji dla klasy AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        DBManager dbManager = new DBManager();

        public AddItemWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            // dodac branie id do nowego itemu
            try
            {
                Item item = new Item(0, ItemName.Text, int.Parse(ItemQuantity.Text), double.Parse(ItemPrice.Text));
                dbManager.addItem(item);
                
            }catch(FormatException)
            {
                MessageBox.Show("Error", "Use numbers in fields with quantity and price. Try again!");
            }

        }
    }
}
