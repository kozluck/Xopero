using System.Collections.Generic;

class EmployeeController
{
    private static List<Employee> employees = new List<Employee>();

    public void addEmployeeToList(Employee employee)
    {
        employees.Add(employee);
    }
    public void removeEmployeeFromListById(int id)
    {
        Employee employee = getEmployeeById(id);
        employees.Remove(employee);
    }
    public List<Employee> getEmployees()
    {
        return employees;
    }
    public void updateEmployeeContract(int id, Contract contract)
    {
        employees[id].setContract(contract);
    }
    public Employee getEmployeeById(int id)
    {
        return employees[id];
    }

}
