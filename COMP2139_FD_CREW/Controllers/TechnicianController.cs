using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// this will need to be changed when it's renamed
using COMP2139_FD_CREW.Models;

namespace COMP2139_FD_CREW.Controllers
{
    public class TechnicianController : Controller
    {


        private SportsProContext context;

        public TechnicianController(SportsProContext contx)
        {
            context = contx;
        }


        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        //----------------------List View

        // List GET method - gets list view.

        [HttpGet]
        public IActionResult List(string id = "All")
        {
            List<Technician> technicians;
            if (id == "All")
            {
                technicians = context.Technicians
                    .OrderBy(p => p.TechnicianId)
                    .ToList();
            }
            else
            {
                // experimenting here
                technicians = context.Technicians
                    .Where(t => t.Name == id)
                    .OrderBy(t => t.TechnicianId)
                    .ToList();
            }

            //ViewBag.Action = "Add";

            return View("TechnicianList", technicians);
        }



        //----------------------Add Technician

        // GET - gets add technician view
        [HttpGet]
        public IActionResult Add()
        {
            Technician technician = new Technician();
            ViewBag.Action = "Add";
            return View("TechnicianEdit", technician);
        }

        // POST - adds technician
        [HttpPost]
        public IActionResult Add(Technician technician)
        {

            if (ModelState.IsValid)
            {
                context.Technicians.Add(technician);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Add";
                return View("TechnicianEdit", technician);
            }
        }

        //----------------------Edit Technician

        // GET - gets edit technician view
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Technician technician = context.Technicians
                .FirstOrDefault(t => t.TechnicianId == id);

            ViewBag.Action = "Edit";
            return View("TechnicianEdit", technician);
        }

        // POST - edit technician
        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (ModelState.IsValid)
            {
                context.Technicians.Update(technician);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Edit";
                return View("TechnicianEdit", technician);
            }
        }

        //----------------------Delete Technician


        // GET - gets delete technician view
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Technician technician = context.Technicians
                .FirstOrDefault(t => t.TechnicianId == id);
            return View("TechnicianDelete", technician);
        }

        // POST - deletes technician

        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
