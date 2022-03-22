using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace COMP2139_FD_CREW.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please input a product code")]
        public String ProductCode { get; set; }

        [Required(ErrorMessage = "Please input a product Name")]
        [RegularExpression("/^([A-Z][a-z]+([ ]?[a-z]?['-]?[A-Z][a-z]+)*)$/",
            ErrorMessage = "Please input a valid, properly formatted Product Name")]
        public String ProductName { get; set; }

        [Required(ErrorMessage = "Please input a price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
