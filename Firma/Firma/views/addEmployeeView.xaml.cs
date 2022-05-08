using System;
using System.Windows;

namespace Firma
{
    public partial class addEmployeeView : Window
    {
        private EmployeeController employeeController = new EmployeeController();
        public addEmployeeView()
        {
            InitializeComponent();

        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee(name.Text, surname.Text);
            try
            {
                employee.setContract(new Contract(typeOfContract.Text, Int32.Parse(monthlyRate.Text), int.Parse(overtimeAmount.Text)));
                employeeController.addEmployeeToList(employee);
                this.Hide();
                MainWindow main = new MainWindow();
                main.Show();
            }
            catch (FormatException)
            {
                MessageBox.Show("Use numbers in fields: Monthly Rate and Overtime Amount.", "Error");
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
