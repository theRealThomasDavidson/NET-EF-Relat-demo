using Microsoft.AspNetCore.Mvc;
using asp_mvc.Models;
using asp_mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace asp_mvc.Controllers
{
    public class BookController: Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //IEnumerable<Book> books = _db.Books;            //for not connected
            IEnumerable<Book> books = _db.Books.Include(c => c.Author).AsNoTracking();
            return View(books);
        
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book obj)
        {

            _db.Books.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
