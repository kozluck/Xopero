using Firma.views;
using System.Windows;
using System.Windows.Media;

namespace Firma
{
    public partial class MainWindow : Window
    {
        private EmployeeController employeeController = new EmployeeController();
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            employeesList.ItemsSource = employeeController.getEmployees();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            employeeController.removeEmployeeFromListById(employeesList.SelectedIndex);
            employeesList.ItemsSource = "";
            employeesList.ItemsSource = employeeController.getEmployees();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window addEmployeeWindow = new addEmployeeView();
            addEmployeeWindow.Show();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedId = employeesList.SelectedIndex;
            this.Hide();
            Window editContractWindow = new editContractView(selectedId);
            editContractWindow.Show();

        }
    }
}
