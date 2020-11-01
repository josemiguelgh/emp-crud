using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using UPS.EmployeeMaintenance.Dtos;
using UPS.EmployeeMaintenance.EmployeeService.Interface;

namespace UPS.EmployeeMaintenance.EmployeeService
{
    public partial class EmployeeServiceRestService : IEmployeeService
    {
        private readonly Uri _apiUrl = new Uri("https://gorest.co.in/public-api/");
        public OperationResult<List<Employee>> GetEmployees(string name)
        {
            IRestClient client = new RestClient(_apiUrl);
            client.UseNewtonsoftJson();
            RestRequest request;
            if(string.IsNullOrWhiteSpace(name))
                request = new RestRequest("users", DataFormat.Json);
            else
                request = new RestRequest("users?name=" + name, DataFormat.Json);

            var response = client.Get<ResponseForApiGetEmployee>(request);
            if (response.IsSuccessful)
                return new OperationResult<List<Employee>> {Succeed = true, Data = response.Data.Data};

            return new OperationResult<List<Employee>> {Succeed = false};
        }

        public OperationResult<string> CreateEmployee(Employee employee)
        {
            try
            {
                IRestClient client = new RestClient(_apiUrl);
                var employeeAsRequest = MapEmployeeAsRequest(employee);
                var message = JsonConvert.SerializeObject(employeeAsRequest);
                var request = new RestRequest("users", DataFormat.Json).AddJsonBody(message);
                request.Method = Method.POST;
                request.AddHeader("authorization", "Bearer " + "fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56");

                var restResponse = client.Post(request);
                if(restResponse.IsSuccessful)
                    return new OperationResult<string> { Succeed = true };
                else
                    return new OperationResult<string> { Succeed = false };

            }
            catch (Exception)
            {
                return new OperationResult<string> { Succeed = false };
            }
        }

        private EmployeeApiRequest MapEmployeeAsRequest(Employee employee)
        {
            return new EmployeeApiRequest{
                Name = employee.Name,
                Email = employee.Email,
                Gender = employee.Gender,
                Status = employee.Status,
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt
            };
        }
    }
}
