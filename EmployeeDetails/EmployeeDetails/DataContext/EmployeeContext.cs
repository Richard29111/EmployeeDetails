using EmployeeDetails.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.DataContext
{
    public class EmployeeContext : DbContext
    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options):base (options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Role> Roles { get; set; }

    }
}
