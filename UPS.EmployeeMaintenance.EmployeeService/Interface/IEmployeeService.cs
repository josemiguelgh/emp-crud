using System.Collections.Generic;
using UPS.EmployeeMaintenance.Dtos;

namespace UPS.EmployeeMaintenance.EmployeeService.Interface
{
    public interface IEmployeeService
    {
        OperationResult<List<Employee>> GetEmployees(string name);
        OperationResult<string> CreateEmployee(Employee employee);
    }
}