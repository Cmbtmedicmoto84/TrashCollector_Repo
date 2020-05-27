using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollectorProject.ActionFilters;
using TrashCollectorProject.Data;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Controllers
{
    //[ServiceFilter(typeof(GlobalRouting))]
    //[Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        readonly ApplicationDbContext db;

        public CustomerController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: Customer
        public ActionResult Index()  //make so that the customer can only see their own information
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = db.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();
            if (customer == null)
            {
                return RedirectToAction("Create");
            }
            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customer = db.Customers.Include(c => c.IdentityUserId).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        [HttpGet]
        // GET: Customer/Create
        public IActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id", "FirstName", "LastName", "Email", "ZipCode", "WeeklyPickUpDay")] Customer customer) //added Create method @ 2:26pm 05/21
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index"); //not redirecting properly
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public IActionResult Edit(int id)
        {
            var customersInDb = db.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(customersInDb);
        }

        // POST: Customer/Edit/5
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

        //GET: Customer/Delete/5
        public IActionResult Delete(int id)
        {
            var customersInDb = db.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Customer customer)
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