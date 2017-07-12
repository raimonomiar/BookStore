using BookStore.Models;
using BookStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository repoC;


        public HomeController(ICategoryRepository _repoC)
        {
            repoC = _repoC;
        }
        
        public ActionResult Index()
        {
            var categorys = repoC.GetCategory();

            return View(categorys);
        }

    }
}