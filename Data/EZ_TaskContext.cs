using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EZ_Task.Models;

namespace EZ_Task.Data
{
    public class EZ_TaskContext : DbContext
    {
        public EZ_TaskContext (DbContextOptions<EZ_TaskContext> options)
            : base(options)
        {
        }

        public DbSet<EZ_Task.Models.Vacation> Vacation { get; set; }

        public DbSet<EZ_Task.Models.Employee> Employee { get; set; }

        public DbSet<EZ_Task.Models.Employee_Vacation_Request> Employee_Vacation_Request { get; set; }
    }
}
