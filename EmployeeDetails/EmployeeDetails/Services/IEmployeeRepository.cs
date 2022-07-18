using EmployeeDetails.Models;
using EmployeeDetails.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> EmployeeList();

        List<Role> loadRole();

        void addEmployee(Employee employee);

        void updateEmployee(Employee employee);

        void deleteEmployee(Employee employee);

       // void Save();

    }
}
