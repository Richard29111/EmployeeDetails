using EmployeeDetails.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.DataContext
{
    public class EmployeeDb : DbContext
    {

        //Const
        public EmployeeDb(DbContextOptions<EmployeeDb> options):base (options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Role> Roles { get; set; }

    }
}
