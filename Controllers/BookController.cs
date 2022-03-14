using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2_luuthieukhue.Models;
using System.ComponentModel.DataAnnotations;

namespace Lab2_luuthieukhue.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "Hello Luu Thieu Khue-University: " + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML5 & CSS Responsive web Design cookbook - Author Name Book 2");
            books.Add("Professional ASP.NET MVCS - Author Name Book 3");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Image/book1cover.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook" ,"Author Name Book 2", "/Content/Image/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVCS"," Author Name Book 3", "/Content/Image/book3cover.jfif"));
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Image/book1cover.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/Image/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVCS", " Author Name Book 3", "/Content/Image/book3cover.jfif"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //Post:Book/EditBook/Id
        [HttpPost ,ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Image/book1cover.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/Image/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVCS", " Author Name Book 3", "/Content/Image/book3cover.jfif"));
            //check if not exit
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_cover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel", books);
        }
        public ActionResult CreatBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreatBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id, Title, Author, ImageCover")] Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Image/book1cover.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/Image/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVCS", " Author Name Book 3", "/Content/Image/book3cover.jfif"));
            try
            {
                if (ModelState.IsValid)
                    books.Add(book);
            }
            catch (RetryLimitExceedExeption)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }

        public ActionResult DeleteBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Image/book1cover.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/Image/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVCS", " Author Name Book 3", "/Content/Image/book3cover.jfif"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //Post:Book/DeleteBook/Id
        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/Image/book1cover.png"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/Image/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVCS", " Author Name Book 3", "/Content/Image/book3cover.jfif"));
            //check if not exit
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_cover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel", books);
        }
    }
}