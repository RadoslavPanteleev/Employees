using System.Globalization;
using System.IO;
using Employees.Models;

namespace Employees.Services
{
    public partial class CsvParserService : ICsvParserService
    {
        private const string ParseDelimiter = ",";

        public string[] GetSupportedDateFormats()
        {
            return DateFormats;
        }

        public async Task<IList<Employee>> Parse(string csvFilePath, string dateFormat)
        {
            List<Employee> employees = [];

            using (StreamReader reader = new StreamReader(csvFilePath))
            {
                int lineIndex = 0;
                try
                {
                    for (; !reader.EndOfStream; lineIndex++)
                    {
                        string? row = await reader.ReadLineAsync();
                        if (row is null)
                            continue;

                        string[] fields = row.Split(ParseDelimiter);

                        Employee employee = new Employee
                        {
                            Id = int.Parse(fields[(int)EmployeeColumnIndexs.ColumnId].Trim()),
                            ProjectId = int.Parse(fields[(int)EmployeeColumnIndexs.ColumnProjectId].Trim()),
                            DateFrom = DateTime.ParseExact(fields[(int)EmployeeColumnIndexs.ColumnDateFrom].Trim(), dateFormat, CultureInfo.InvariantCulture)
                        };

                        string dateTo = fields[(int)EmployeeColumnIndexs.ColumnDateTo].Trim();
                        if (string.Compare(dateTo, "null", StringComparison.OrdinalIgnoreCase) == 0)
                            employee.DateTo = DateTime.Now;
                        else
                            employee.DateTo = DateTime.ParseExact(dateTo, dateFormat, CultureInfo.InvariantCulture);

                        employees.Add(employee);
                    }
                }
                catch (FormatException ex)
                {
                    throw new Exception($"Invalid format at line {lineIndex}. Message: {ex.Message}");
                }
            }

            return employees;
        }
    }
}
