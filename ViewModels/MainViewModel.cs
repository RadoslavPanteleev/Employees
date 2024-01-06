using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using Employees.Models;
using Employees.Services;

namespace Employees.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ParseAndFindCommand))]
        private string csvFilePath = string.Empty;

        [ObservableProperty]
        private string[] supportedDateFormats;

        [ObservableProperty]
        private string selectedDateFormat = string.Empty;

        [ObservableProperty]
        private IList<Employee> parsedEmployees = new List<Employee>();

        [ObservableProperty]
        private IList<EmployeePair> employeesPairs = new List<EmployeePair>();

        private readonly ICsvParserService csvParserService;
        private readonly ICalculatePairsService calculatePairsService;


        public MainViewModel(ICsvParserService _csvParserService, ICalculatePairsService _calculatePairsService)
        {
            csvParserService = _csvParserService;
            calculatePairsService = _calculatePairsService;

            SupportedDateFormats = csvParserService.GetSupportedDateFormats();
        }

        [RelayCommand(CanExecute = nameof(IsNullFilePath))]
        public async Task ParseAndFindAsync()
        {
            if(string.IsNullOrEmpty(SelectedDateFormat))
            {
                ShowNotification("Please choose date format!");
                return;
            }

            try
            {
                ParsedEmployees.Clear();
                EmployeesPairs.Clear();

                ParsedEmployees = await csvParserService.Parse(CsvFilePath, SelectedDateFormat);
                EmployeesPairs = await Task.Run(() => calculatePairsService.CalculatePairs(ParsedEmployees));
            }
            catch(Exception ex)
            {
                ShowNotification(ex.Message);
                Debug.WriteLine(ex);

                return;
            }
        }

        private bool IsNullFilePath() => CsvFilePath != string.Empty;
    }
}
