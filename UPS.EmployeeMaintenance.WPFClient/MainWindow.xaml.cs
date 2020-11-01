using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UPS.EmployeeMaintenance.WPFClient.Helpers;

namespace UPS.EmployeeMaintenance.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public static class SingleWindowsManager
    {
        public static void CreateWindow<T>() where T : SingleInstanceWindow, new()
        {
            var newWindow = new T();
            if (!string.IsNullOrEmpty(newWindow.CreationStatus) && newWindow.CreationStatus == Constants.ShouldBeClosed)
            {
                newWindow.Close();
                return;
            }
            newWindow.Show();
        }
    }
}
