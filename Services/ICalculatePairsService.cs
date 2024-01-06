using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Models;

namespace Employees.Services
{
    public interface ICalculatePairsService
    {
        IList<EmployeePair> CalculatePairs(IList<Employee> parsedEmployees);
    }
}
