using Firma.models;
using System;

namespace Firma.models
{
    public class Employee
    {
        private String name;
        private String surname;
        private Contract contract;


        public Employee(String name, String surname)
        {
            this.name = name;
            this.surname = surname;
            this.contract = new Internship();
        }

        public void setContract(Contract contract) => this.contract = contract;

        public double getSalary()
        {
            return this.contract.Salary();
        }

        public override string ToString()
        {
            return $"{this.name} {this.surname} {this.contract.Salary()}";
        }
    }
}

