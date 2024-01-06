using Employees.Models;

namespace Employees.Services
{
    public interface ICsvParserService
    {
        Task<IList<Employee>> Parse(string csvFilePath, string dateFormat);

        string[] GetSupportedDateFormats();
    }
}
