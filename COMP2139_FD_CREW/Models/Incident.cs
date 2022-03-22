using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace COMP2139_FD_CREW.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }

        public int CustomerId { set; get; }
        public Customer Customer { get; set;  }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int? TechnicianId { get; set; }
        public Technician Technician { get; set; }


        [Required(ErrorMessage = "Please input an incident title")]
        [RegularExpression("/^([A-Z][a-z]+([ ]?[a-z]?['-]?[A-Z][a-z]+)*)$/",
            ErrorMessage = "Please input a valid, properly formatted title")]
        public String Title { get; set; }


        public DateTime dateOpened { get; set; }
        
        public DateTime dateClosed { get; set; }
    }
}
