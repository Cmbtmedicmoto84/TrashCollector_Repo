using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrashCollectorProject.ActionFilters;
using TrashCollectorProject.Data;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Controllers
{
    [ServiceFilter(typeof(GlobalRouting))]
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
            var customers = db.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(Customer customer)
        {
            var customers = new Customer();
            return View(customers);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            Customer customers = new Customer();
            return View("Create");
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id", "FirstName", "LastName", "Email", "ZipCode", "WeeklyPickUpDay")] Customer customers) //added Create method @ 2:26pm 05/21
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customers.IdentityUserId = userId;
                var customer = db.Customers.ToList();
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index"); //not redirecting properly
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var customersInDb = db.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(customersInDb);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customers)
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

        // GET: Customer/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Customer/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}