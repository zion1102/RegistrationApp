using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


// this will need to be changed when it's renamed
using COMP2139_FD_CREW.Models;

namespace COMP2139_FD_CREW.Controllers
{
    public class RegistrationController : Controller
    {
        //----------------------List View


        // List GET method - gets list view. Incomplete
        [HttpGet]
        public IActionResult List()
        {
            return View("RegistrationList");
        }


        //----------------------Add Registration

        // GET - gets add registration view - incomplete
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add Registration";
            return View("RegistrationEdit");
        }

        // POST - adds registration - incomplete
        [HttpPost]
        public IActionResult Add(Registration model)
        {
            return View("RegistrationEdit");
        }

        //----------------------Edit Registration

        // GET - gets edit registration view - incomplete
        [HttpGet]
        public IActionResult Edit()
        {
            ViewBag.Title = "Edit Registration";
            return View("RegistrationEdit");
        }

        // POST - edit registration - incomplete
        [HttpPost]
        public IActionResult Edit(Registration model)
        {
            return View("RegistrationEdit");
        }


        //----------------------Delete Registration 


        // GET - gets delete registration view - incomplete
        [HttpGet]
        public IActionResult Delete()
        {
            return View("RegistrationDelete");
        }

        // DELETE - deletes registration - incomplete 
        [HttpDelete]
        public IActionResult Delete(Registration model)
        {
            return View("RegistrationDelete");
        }
    }
}
