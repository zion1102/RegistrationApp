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
    public class IncidentController : Controller
    {
        private SportsProContext context;
        private List<Product> products;
        private List<Technician> technicians;
        private List<Customer> customers;


        public IncidentController(SportsProContext contx)
        {
            context = contx;
            products = context.Products
                    .OrderBy(c => c.ProductId)
                    .ToList();
        }

        //----------------------List View


        // List GET method - gets list view.
        [HttpGet]
        public IActionResult List(string id = "All")
        {
            List<Incident> incidents;
            if (id == "All")
            {
                incidents = context.Incidents
                    .OrderBy(p => p.IncidentId)
                    .ToList();
            }
            else
            {
                // experimenting here
                incidents = context.Incidents
                    .Where(i => i.Title == id)
                    .OrderBy(t => t.TechnicianId)
                    .ToList();
            }

            ViewBag.Products = products;
            ViewBag.Customers = customers;
            ViewBag.Technicians = technicians;
            return View("IncidentList", incidents);
        }


        //----------------------Add Incident

        // GET - gets add incident view 
        [HttpGet]
        public IActionResult Add()
        {
            Incident incident = new Incident();
            
            // this is probably wrong;
            incident.Product = context.Products.Find(1);
            incident.Technician = context.Technicians.Find(1);
            incident.Customer = context.Customers.Find(1);
            ViewBag.Action = "Add";
            ViewBag.Products = products;
            ViewBag.Technicians = technicians;
            ViewBag.Customers = customers;
            
            return View("IncidentEdit", incident);
        }

        // POST - adds incident - incomplete
        [HttpPost]
        public IActionResult Add(Incident incident)
        {

            if (ModelState.IsValid)
            {
                context.Incidents.Add(incident);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                incident.Product = context.Products.Find(1);
                incident.Technician = context.Technicians.Find(1);
                incident.Customer = context.Customers.Find(1);
                ViewBag.Action = "Add";
                ViewBag.Products = products;
                ViewBag.Technicians = technicians;
                ViewBag.Customers = customers;
                return View("TechnicianEdit", incident);
            }
        }


        //----------------------Edit Incident

        // GET - gets edit incident view - incomplete
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Incident incident = context.Incidents
                .Include(i => i.Product)
                .Include(i => i.Customer)
                .Include(i => i.Technician)
                .FirstOrDefault(i => i.IncidentId == id);

            ViewBag.Action = "Edit";
            ViewBag.Products = products;
            ViewBag.Technicians = technicians;
            ViewBag.Customers = customers;

            return View("IncidentEdit", incident);

        }

        // POST - edit incident - incomplete
        
        [HttpPost]
        public IActionResult Upda(Incident incident)
        {

            if (ModelState.IsValid)
            {
                context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                incident.Product = context.Products.Find(1);
                incident.Technician = context.Technicians.Find(1);
                incident.Customer = context.Customers.Find(1);
                ViewBag.Action = "Edit";
                ViewBag.Products = products;
                ViewBag.Technicians = technicians;
                ViewBag.Customers = customers;
                return View("TechnicianEdit", incident);
            }
        }


        //----------------------Delete Incident


        // GET - gets delete incident view - incomplete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Incident incident = context.Incidents
                 .FirstOrDefault(i => i.IncidentId == id); 
            return View("IncidentDelete");
        }

        // DELETE - deletes incident - incomplete 
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
