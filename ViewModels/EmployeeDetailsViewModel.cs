using EZ_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace EZ_Task.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        public List<Vacation>  Vacations { get; set; }
        public Employee Employee { get; set; }
     }
}
