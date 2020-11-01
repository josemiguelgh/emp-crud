using System;
using Newtonsoft.Json;

namespace UPS.EmployeeMaintenance.EmployeeService
{
    public partial class EmployeeServiceRestService
    {
        public class EmployeeApiRequest
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("gender")]
            public string Gender { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
            
            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public DateTime UpdatedAt { get; set; }
        }
    }
}