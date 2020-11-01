namespace UPS.EmployeeMaintenance.Dtos
{
    public class OperationResult<T>
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}