using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZ_Task.Models
{
    public class Vacation
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }

        public int Allowance { get; set; }

        public static implicit operator Vacation(List<Vacation> v)
        {
            throw new NotImplementedException();
        }
    }
}
