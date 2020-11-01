using System.Collections.Generic;
using UPS.EmployeeMaintenance.Dtos;

namespace UPS.EmployeeMaintenance.EmployeeService
{
    public class ResponseForApiGetEmployee
    {
        public string Code { get; set; }
        public List<Employee> Data { get; set; }
    }
}