using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_Task.Models
{
    public class Employee_Vacation_Request
    {
       public int Id { get; set; }
       [Required]
       [DataType(DataType.Date)]
       public DateTime StartDate { get; set; }

       [Required]
       [DataType(DataType.Date)]
       public DateTime EndDate { get; set; }
       public int EmployeeId { get; set; }
       public int VacationId { get; set; }

       public virtual Employee Employee { get; set; }
       public virtual Vacation Vacation { get; set; }

    }
}
