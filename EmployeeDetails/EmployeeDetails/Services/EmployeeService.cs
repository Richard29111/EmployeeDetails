using EmployeeDetails.DataContext;
using EmployeeDetails.Models;
using EmployeeDetails.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.Service
{
    public class EmployeeService : IEmployeeRepository
    {
        private readonly EmployeeDb _context;

        public EmployeeService(EmployeeDb context)
        {
            _context = context;
        }

        public List<Role> loadRole()
        {
            try
            {
                List<Role> RoleList = new List<Role>();

                RoleList = _context.Roles.ToList();

                return RoleList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void addEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChangesAsync();
            return;
        }

        public void deleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChangesAsync();
        }

        public List<Employee> EmployeeList()
        {
            return _context.Employees.Include(r => r.Role).ToList();
        }

        //public List<Role> RoleList()
        //{
        //    return _context.Employees.Include(r => r.Role).ToList();
        //}

       //// public void Save()
       // {
       //     throw new NotImplementedException();
       // }

        public void updateEmployee(Employee employee)
        {
            
            _context.Update(employee);
           _context.SaveChangesAsync();
        }

        //public List<Role> RoleList()
        //{

        //        List<Role> RoleList = new List<Role>();

        //        RoleList = _context.Roles.ToList();

        //        return RoleList;
        //    }

        //}

        //public void addEmployee(Employee employee)
        //{

        //    {
        //        _context.Add(employee);
        //        _context.SaveChangesAsync();
        //        return;
        //    }

        //}

        //public void deleteEmployee(Employee employee)
        //{

        //    {
        //        _context.Employee.Remove(employee);
        //        _context.SaveChangesAsync();

        //    }

        //}

        //public List<Employee> EmployeeList()
        //{
        //    {
        //        return _context.Employee
        //        .Include(d => d.Department).ToList();

        //    }
        //}



        //public void updateEmployee(Employee employee)
        //{

        //    {
        //        _context.Update(employee);
        //        _context.SaveChangesAsync();
        //    }

        //}

        private void NotFound()
        {
            throw new NotImplementedException();
        }
    }
}

