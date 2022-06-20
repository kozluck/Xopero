using System;
using System.Windows;

namespace ShopManager
{

    public partial class MainWindow : Window
    {
        //Aby zmienic rodzaj bazy danych wystarczy zmienic obiekt jaki przyjmuje DBManager na: SQLite lub LiteDBManager
        DBManager dbManager = new(new SQLite());
        public MainWindow()
        {
            InitializeComponent();

            ItemsGrid.ItemsSource = dbManager.GetItems();
        }
        protected override void OnContentRendered(EventArgs e)
        {
            ItemsGrid.ItemsSource = dbManager.GetItems();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddItemWindow window = new();
            window.Show();
            this.Hide();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            Item item = (Item)ItemsGrid.SelectedItem;
            dbManager.deleteItemById(item.Id);
            ItemsGrid.ItemsSource = dbManager.GetItems();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Item item = (Item)ItemsGrid.SelectedItem;
            editWindow editWindow = new(item.Id);
            editWindow.Show();
            this.Hide();
        }
    }
}
