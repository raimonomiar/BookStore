using BookStore.Models;
using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using BookStore.Repository;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookRepository repoB;
        private readonly ICategoryRepository repoC;

        public BookController(IBookRepository _repoB,ICategoryRepository _repoC)
        {
            repoB = _repoB;
            repoC = _repoC;
        }

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddCategory()
        {
            var catModel = new CategoryViewModel();

            return View("Category", catModel);
        } 

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(CategoryViewModel _catModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Category");  
            }
            var category = new Category
            {
                name = _catModel.name
            };
            repoC.Add(category);


            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Add()
        {
            var Category = repoC.GetCategory();

            var bModel = new BookViewModels
            {
                Categorys = Category
            };

            return View("Book",bModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BookViewModels _bModel)
        {

            if (!ModelState.IsValid)
            {
                _bModel.Categorys = repoC.GetCategory();

                return View("Book", _bModel);
            }

            var books = new Book
            {
                Title = _bModel.Title,
                Author = _bModel.Author,
                Publisher= _bModel.Publisher,
                Edition=_bModel.Edition,
                Price=_bModel.Price,
                CategoryId=_bModel.CategoryId,
                UserId = User.Identity.GetUserId()
                
            };
            repoB.Add(books);

            return RedirectToAction("ShowMyBooks");
        }

        [Authorize]
        public ActionResult ShowMyBooks()
        {
            var UserId = User.Identity.GetUserId();

            var MyBooks = repoB.FindByID(UserId);
                

            return View("MyBook", MyBooks);
        }

       
        public ActionResult BrowseByCategory(int id)
        {
            var book = repoB.Browse(id);

            if (book==null)
            {
                return HttpNotFound();
            }

            return View("Browse", book);

        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();

            var books = repoB.FindBook(id, userId);
            if (books==null)
            {
                return HttpNotFound();
            }

            var bModel = new BookViewModels
            {
                Id = books.Id,
                Author = books.Author,
                Title = books.Title,
                Publisher = books.Publisher,
                Edition = books.Edition,
                CategoryId = books.Id,
                Categorys = repoC.GetCategory(),
                Price=books.Price
            };

            return View("Book", bModel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(BookViewModels _bModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Book", _bModel);
            }

            var userId = User.Identity.GetUserId();

            var book = repoB.FindBook(_bModel.Id,userId);

            book.Author = _bModel.Author;
            book.Edition = _bModel.Edition;
            book.CategoryId = _bModel.CategoryId;
            book.Title = _bModel.Title;
            book.Publisher = _bModel.Publisher;
            book.Price = _bModel.Price;

            repoB.Edit(book);

            return RedirectToAction("ShowMyBooks");
        }

    }
}