using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Models
{
    public class EmployeePair
    {
        public int Employee1Id { get; set; }

        public int Employee2Id { get; set; }

        public int ProjectId { get; set; }

        public int WorkedDays { get; set; }
    }
}
