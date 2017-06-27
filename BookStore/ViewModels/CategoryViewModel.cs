using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels
{
    public class CategoryViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name ="Category Name")]
        [StringLength(80)]
        public string name { get; set; }
    }
}