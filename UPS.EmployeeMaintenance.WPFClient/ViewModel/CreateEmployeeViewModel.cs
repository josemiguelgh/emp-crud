using System;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using UPS.EmployeeMaintenance.Dtos;
using UPS.EmployeeMaintenance.EmployeeService.Interface;
using UPS.EmployeeMaintenance.WPFClient.Helpers;

namespace UPS.EmployeeMaintenance.WPFClient.ViewModel
{
    public class CreateEmployeeViewModel : ViewModelCustomBase<CreateEmployeeViewModel>
    {
        private readonly IEmployeeService _employeeService;

        public ICommand CreateEmployeeCommand { get; }


        private string _name;
        [Required(AllowEmptyStrings = false)]
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                    return;
                _name = value;
                RaisePropertyChanged(vm => vm.Name);
            }
        }

        private string _email;
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email
        {
            get => _email;
            set
            {
                if (_email == value)
                    return;
                _email = value;
                RaisePropertyChanged(vm => vm.Email);
            }
        }

        private string _gender;
        [Required(AllowEmptyStrings = false)]
        [StringRange(AllowableValues = new[] { "Male", "Female" })]
        public string Gender
        {
            get => _gender;
            set
            {
                if (_gender == value)
                    return;
                _gender = value;
                RaisePropertyChanged(vm => vm.Gender);
            }
        }

        private string _status;
        [Required(AllowEmptyStrings = false)]
        [StringRange(AllowableValues = new[] { "Active", "Inactive" })]
        public string Status
        {
            get => _status;
            set
            {
                if (_status == value)
                    return;
                _status = value;
                RaisePropertyChanged(vm => vm.Status);
            }
        }

        public CreateEmployeeViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            CreateEmployeeCommand = new RelayCommand(CreateEmployee);
        }

        private void CreateEmployee()
        {
            if (!ValidateObject())
                return;

            var employee = new Employee()
            {
                Name = Name, Email = Email, Gender = Gender, Status = Status, 
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var operationResult = _employeeService.CreateEmployee(employee);
            if (operationResult.Succeed)
            {
                Name = "Employee Created Successfully!";
                Email = "";
                Gender = "";
                Status = "";
            }
        }
    }
}