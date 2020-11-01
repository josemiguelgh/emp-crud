using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using UPS.EmployeeMaintenance.Dtos;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using UPS.EmployeeMaintenance.EmployeeService;
using UPS.EmployeeMaintenance.EmployeeService.Interface;

namespace UPS.EmployeeMaintenance.WPFClient.ViewModel
{

    public class MainViewModel : ViewModelCustomBase<MainViewModel>
    {
        private ObservableCollection<Employee> _filteredEmployees;
        private readonly IEmployeeService _employeeService;
        private string employeeNameSearchPattern;


        public ObservableCollection<Employee> FilteredEmployees
        {
            get => _filteredEmployees;
            set
            {
                if (value == _filteredEmployees)
                    return;
                _filteredEmployees = value;
                RaisePropertyChanged(vm => vm.FilteredEmployees);
            }
        }
        public string EmployeeNameSearchPattern
        {
            get { return employeeNameSearchPattern; }
            set
            {
                if (employeeNameSearchPattern == value)
                    return;
                employeeNameSearchPattern = value;
                RaisePropertyChanged("EmployeeNameSearchPattern");
            }
        }
        public ICommand SearchEmployeesCommand { get; }
        public ICommand CreateEmployeeCommand { get; }


        public MainViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

            SearchEmployeesCommand = new RelayCommand(SearchEmployees);
            CreateEmployeeCommand = new RelayCommand(CreateEmployee);

            SearchEmployees();
        }

        private void SearchEmployees()
        {
            var operationResult = _employeeService.GetEmployees(EmployeeNameSearchPattern);
            if (operationResult.Succeed)
                FilteredEmployees = new ObservableCollection<Employee>(operationResult.Data);
        }

        private void CreateEmployee()
        {
            SingleWindowsManager.CreateWindow<CreateEmployee>();
        }
    }
}