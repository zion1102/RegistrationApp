using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// this will need to be changed when it's renamed
using COMP2139_FD_CREW.Models;

namespace COMP2139_FD_CREW.Controllers
{
    public class CustomerController : Controller
    {

        private SportsProContext context;
        private List<Country> countries;
        //private List<Incident> incidents;
        //private List<Technician> technicians;

        public CustomerController(SportsProContext contx)
        {
            context = contx;
            countries = context.Countries
                .OrderBy(c => c.CountryId)
                .ToList();
        }


        public IActionResult Index()
        {
            return RedirectToAction("List");
        }


        //----------------------List View


        // List GET method - gets list view.
        [HttpGet]
        public IActionResult List()
        {
            List<Customer> customers;
          
            customers = context.Customers
                .OrderBy(p => p.CustomerId)
                .ToList();
            

            //ViewBag.Action = "Add";
            return View("CustomerList", customers);
        }





        //----------------------Add Customer

        // GET - gets add customer view
        [HttpGet]
        public IActionResult Add() 
        {
            Customer customer = new Customer();
            customer.Country = context.Countries.Find("CAN");
            ViewBag.Action = "Add";
            ViewBag.Countries = countries;
            return View("CustomerEdit", customer);
        }

        // POST - adds customer
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Add";
                return View("CustomerEdit", customer);
            }
        }

        //----------------------Edit Customer

        // GET - gets edit customer view
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            Customer customer = context.Customers
                .Include(c => c.Country)
                .FirstOrDefault(p => p.CustomerId == id);


            ViewBag.Action = "Edit";
            return View("CustomerEdit", customer);
        }

        // POST - edit customer - incomplete
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Update(customer);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Edit";
                return View("CustomerEdit", customer);
            };
        }


        //----------------------Delete Customer 


        // GET - gets delete customer view - incomplete
        [HttpGet]
        public IActionResult Delete(int id) 
        {

            Customer customer = context.Customers
                .FirstOrDefault(c => c.CustomerId == id);

            return View("CustomerDelete", customer);
        }

        // POST - deletes customer - incomplete 
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return View("CustomerDelete");
        }

    }
}
