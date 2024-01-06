using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }

    public enum EmployeeColumnIndexs : int
    { 
        ColumnId,
        ColumnProjectId,
        ColumnDateFrom,
        ColumnDateTo
    }
}
