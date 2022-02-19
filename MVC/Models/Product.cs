using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetExam.Models
{
    public class Product
    {   
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Product Name is Required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Rate is Required")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryName { get; set; }
    }
}