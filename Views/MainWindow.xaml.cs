using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Win32;
using System.Windows;
using Employees.ViewModels;

namespace Employees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel? viewModel;

        public MainWindow()
        {
            InitializeComponent();

            this.viewModel = Ioc.Default.GetService<MainViewModel>();
            if(viewModel != null)
                this.viewModel.NotificationRequest += ViewModel_NotificationRequest;

            DataContext = viewModel;
        }

        private void ViewModel_NotificationRequest(object? sender, string e)
        {
            MessageBox.Show(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Browse for CSV file, to parse...",
                Filter = "CSV Files|*.csv",
                CheckFileExists = true,
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == false)
                return;

            if(viewModel is not null)
                viewModel.CsvFilePath = openFileDialog.FileName;
        }
    }
}