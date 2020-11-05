using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_Task.Models
{
    public enum Gender
    {
        Male,
        Female
        
    }
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Fullname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender   { get; set; }
        [Required()]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
 
    }
}
