﻿using System;
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
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        readonly ApplicationDbContext db;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        
        
        // GET: Employee
        public IActionResult Index()
        {
            //Find currently logged in employee so we can find their zipcode
            //Then we can alter the var customers query below so that we can find just the customers in logged in employee's zipcode
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = db.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();
            if (employee == null)
            {
                return RedirectToAction("Create");
            }
            var customers = db.Customers.ToList();
            return View(customers);  
        }

        // GET: Employee/Details/5
        public IActionResult Details(int id)
        {
            var employee = new Employee();
            return View("Index");
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName", "LastName", "EmployeeId", "ZipCode")]Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(int id)
        {
            var customersInDb = db.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(customersInDb);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customers)
        {
            var customersInDb = db.Customers.Where(c => c.Id == id).FirstOrDefault();
            Customer customer = null;
            try
            {
                // TODO: Add update logic here
                customer.WeeklyPickUpDay = Request.Form["WeeklyPickUpDay"];
                db.Customers.Update(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
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