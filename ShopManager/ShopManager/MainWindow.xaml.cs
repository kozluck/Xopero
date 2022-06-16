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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopManager
{

    public partial class MainWindow : Window
    {
        DBManager dbManager = new();
        public MainWindow()
        {
            InitializeComponent();

            DBManager.db = new SQLite();
            List<Item> items = dbManager.GetItems();
            ItemsGrid.ItemsSource = items;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddItemWindow window = new();
            window.Show();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            Item item = (Item) ItemsGrid.SelectedItem;
            dbManager.deleteItemById(item.Id);
            ItemsGrid.ItemsSource = dbManager.GetItems();
        }
    }
}
