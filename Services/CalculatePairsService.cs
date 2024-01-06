using Employees.Models;

namespace Employees.Services
{
    public class CalculatePairsService : ICalculatePairsService
    {
        public IList<EmployeePair> CalculatePairs(IList<Employee> parsedEmployees)
        {
            List<EmployeePair> employeePairs = [];

            var employeesGroupedByProjectID =
                parsedEmployees.GroupBy(e => e.ProjectId) // Групираме по проекти
                .Where(group => group.Count() > 1) // Махаме единичните групи
                .OrderBy(group => group.Key);
                
            Parallel.ForEach(employeesGroupedByProjectID, // Паралелно за всяка група от служители, за всеки проект
                currentProject => {
                    foreach(var employee1 in currentProject)
                    {
                        foreach(var employee2 in currentProject)
                        {
                            if (employee1.Id == employee2.Id)
                                continue;

                            if (employeePairs.Exists(pair => pair.Employee1Id == employee2.Id && pair.Employee2Id == employee1.Id))
                                continue;

                            DateTime employeeDateFrom1 = employee1.DateFrom;
                            DateTime employeeDateTo1 = employee1.DateTo;
                            DateTime employeeDateFrom2 = employee2.DateFrom;
                            DateTime employeeDateTo2 = employee2.DateTo;

                            int daysOverlaped = Utills.Utills.GetOverlappingDays(employeeDateFrom1, employeeDateTo1, employeeDateFrom2, employeeDateTo2);
                            if(daysOverlaped > 0)
                            {
                                employeePairs.Add(new EmployeePair
                                {
                                    Employee1Id = employee1.Id,
                                    Employee2Id = employee2.Id,
                                    ProjectId = currentProject.Key,
                                    WorkedDays = daysOverlaped
                                });
                            }
                        }
                    }
                });
            
            return employeePairs.OrderByDescending(o => o.WorkedDays).ToList();
        }
    }
}
