using Firma.controllers;
using Firma.models;
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
                if (typeOfContract.Text.Equals("Staż"))
                    employee.setContract(new Internship(Int32.Parse(monthlyRate.Text), int.Parse(overtimeAmount.Text)));
                else
                    employee.setContract(new Fulltime(Int32.Parse(monthlyRate.Text), int.Parse(overtimeAmount.Text)));
                
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
