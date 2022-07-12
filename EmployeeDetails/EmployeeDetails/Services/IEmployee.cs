using EmployeeDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Repository
{
    public interface IEmployee
    {
        List<Employee> GetAll();

        Employee GetById(int Id);

        void Insert(Employee employee);

        void Update(Employee employee);

        void Delete(Employee employee);

        void Save();

    }
}
