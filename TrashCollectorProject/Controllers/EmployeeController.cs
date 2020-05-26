using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrashCollectorProject.ActionFilters;
using TrashCollectorProject.Data;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Controllers
{
    //[ServiceFilter(typeof(GlobalRouting))]
    //[Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        readonly ApplicationDbContext db;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        
        
        // GET: Employee
        public ActionResult Index()
        {
            //Find currently logged in employee so we can find their zipcode
            //Then we can alter the var customers query below so that we can find just the customers in logged in employee's zipcdoe
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = db.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();
            var customers = db.Customers.ToList();
            return View(customers);  //change to customer before finshing
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("FirstName", "LastName", "EmployeeId", "ZipCode")]Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Log in");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}