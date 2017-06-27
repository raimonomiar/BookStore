using BookStore.Controllers;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace BookStore.ViewModels
{
    public class BookViewModels
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Authors")]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Enter a valid 4 digit Year")]
        [Display(Name = "Edition Year")]
        public int Edition { get; set; }

        [Required]
        [RegularExpression(@"^\d{0,8}(\.\d{1,4})?$",ErrorMessage ="Enter a valid Amount.")]
        public Decimal Price { get; set; }

        public IEnumerable<Category> Categorys{ get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<BookController, ActionResult>> Edit = (c => c.Edit(this));
                Expression<Func<BookController, ActionResult>> Add= (c => c.Add(this));
                var action = (Id != 0) ? Edit : Add;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

    }
}