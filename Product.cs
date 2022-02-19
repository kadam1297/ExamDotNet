using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamMVC.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Name can not be Empty")]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please Enter Rate")]
        [DataType(DataType.Currency)]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Describe somthing")]
        [DataType(DataType.Text)]
        [MaxLength(200)]

        public string Description { get; set; }

        [Required(ErrorMessage = "Please choose category")]
        
        public int category { get; set; }
        public object CategoryName { get; internal set; }
    }
}