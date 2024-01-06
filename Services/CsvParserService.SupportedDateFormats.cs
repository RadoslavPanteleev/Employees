using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Services
{
    public partial class CsvParserService : ICsvParserService
    {
        public static readonly string[] DateFormats =
        [
            "yyyy-MM-dd", 
            "yyyy/MM/dd", 
            "yyyy.MM.dd",
            "yyyy-dd-MM", 
            "yyyy/dd/MM", 
            "yyyy.dd.MM",
            "MM-dd-yyyy", 
            "MM/dd/yyyy", 
            "MM.dd.yyyy",
            "MMM-dd-yyyy", 
            "MMM/dd/yyyy", 
            "MMM.dd.yyyy",
            "MMMM-dd-yyyy", 
            "MMMM/dd/yyyy", 
            "MMMM.dd.yyyy"
        ];
    }
}
