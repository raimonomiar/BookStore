using BookStore.Models;
using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController()
        {
            _context = new ApplicationDbContext();
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
            _context.Categorys.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Add()
        {
            var Category = _context.Categorys.ToList();

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
                _bModel.Categorys = _context.Categorys.ToList();

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

            _context.Books.Add(books);
            _context.SaveChanges();

            return RedirectToAction("ShowMyBooks");
        }

        [Authorize]
        public ActionResult ShowMyBooks()
        {
            var UserId = User.Identity.GetUserId();

            var MyBooks = _context.Books
                .Where(u => u.UserId == UserId)
                .Include(c=>c.Categorys)
                .ToList();

            return View("MyBook", MyBooks);
        }

       
        public ActionResult BrowseByCategory(string name)
        {
            var book = _context.Books
                .Where(b => b.Categorys.name == name)
                .ToList();

            if (book==null)
            {
                return HttpNotFound();
            }

            return View("Browse", book);

        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var books = _context.Books
                .Include(c => c.Categorys)
                .Include(u => u.Users)
                .SingleOrDefault(b => b.Id == id);
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
                Categorys = _context.Categorys.ToList(),
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

            var book = _context.Books
                .Single(b=>b.Id == _bModel.Id && b.UserId == userId);

            book.Author = _bModel.Author;
            book.Edition = _bModel.Edition;
            book.CategoryId = _bModel.CategoryId;
            book.Title = _bModel.Title;
            book.Publisher = _bModel.Publisher;
            book.Price = _bModel.Price;

            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("ShowMyBooks");
        }

    }
}