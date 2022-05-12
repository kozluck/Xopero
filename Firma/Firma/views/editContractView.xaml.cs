using Firma.controllers;
using Firma.models;
using System;
using System.Windows;

namespace Firma.views
{
    public partial class editContractView : Window
    {
        private int employeeId;
        private EmployeeController employeeController = new EmployeeController();

        public editContractView(int id)
        {
            InitializeComponent();
            employeeId = id;
        }

        private void updateContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int monthlyRateValue = Int32.Parse(monthlyRate.Text);
                int overtimeAmountValue = Int32.Parse(overtimeAmount.Text);
                Contract contract;

                if (contractType.Text.Equals("Etat"))
                    contract = new Fulltime(monthlyRateValue, overtimeAmountValue);
                else
                    contract = new Internship(monthlyRateValue, overtimeAmountValue);

                Employee employee = employeeController.getEmployeeById(employeeId);
                employee.setContract(contract);

                this.Hide();
                MainWindow main = new MainWindow();
                main.Show();
            }
            catch (FormatException)
            {
                MessageBox.Show("Use numbers in fields: Monthly Rate and Overtime Amount.", "Error");
            }

        }
    }
}
