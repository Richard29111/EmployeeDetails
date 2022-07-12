using EmployeeDetails.DataContext;
using EmployeeDetails.Models;
using EmployeeDetails.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Service
{
    public class EmployeeRepository : IEmployee
    {
        private EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int EmployeeID)
        {
            return _context.Employees.Where(x => x.EmployeeID == EmployeeID).FirstOrDefault();
        }

        public void Insert(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }
    }
}
