using Microsoft.AspNetCore.Mvc;
using asp_mvc.Models;
using asp_mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace asp_mvc.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<Author> authors = _db.Authors.Include(c => c.Books).AsNoTracking();
            return View(authors);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author obj)
        {
            _db.Authors.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
