using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeDetails.DataContext;
using EmployeeDetails.Models;
using EmployeeDetails.Repository;
using Microsoft.Extensions.Configuration;

namespace EmployeeDetails.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDb _context;
        private readonly IEmployeeRepository _empRepo;


        public EmployeesController(EmployeeDb context, IEmployeeRepository empRepo)
        {
            _context = context;
            _empRepo = empRepo;

        }



        public IActionResult Index()
        {

            {
                List<Employee> employees = _empRepo.EmployeeList();
                return View(employees);

            }

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Role)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        public IActionResult Create()
        {

            {
                ViewBag.RoleList = _empRepo.loadRole();
                ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleID");
                return View(); //This Display role options

            }

        }



        [HttpPost]
        public IActionResult Create([Bind("EmployeeID,FirstName,LastName,City,Country,RoleID")] Employee employee)
        {

            {
                if (ModelState.IsValid)
                {
                    _empRepo.addEmployee(employee);

                }
                //ViewData["RoleID"] = new SelectList( "RoleID", "RoleID" );
                // return View(employee);
                return RedirectToAction("Index");

            }

        }

        public async Task<IActionResult> Edit(int? id)
        {

            {
                if (id == null)
                {
                    return NotFound();
                }
                ViewBag.RoleList = _empRepo.EmployeeList();
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleID", employee.RoleID); //Drop down
                return View(employee);


            }

        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("EmployeeID,FirstName,LastName,City,Country,RoleID")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                {
                    _empRepo.updateEmployee(employee);
                }

            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = await _context.Employees
                    .Include(e => e.Role)
                    .FirstOrDefaultAsync(m => m.EmployeeID == id);
                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    _empRepo.deleteEmployee(employee);

                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }
    }
}