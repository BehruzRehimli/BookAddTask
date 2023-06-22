using HomeworkPustok.DAL;
using HomeworkPustok.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeworkPustok.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AuthorController : Controller
    {
        private readonly PustokDbContext _context;
        public AuthorController(PustokDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            var datas=_context.Authors.Include(x=>x.Books).ToList();
            return View(datas);
        }
        public IActionResult Update(int id)
        {
            var data = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (data == null) return RedirectToAction("Error");
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var data = _context.Authors.FirstOrDefault(x => x.Name.Trim().ToLower() == author.Name.ToLower().Trim());
            if (data != null && data.Id != author.Id)
            {
                ModelState.AddModelError("Name", "Bu adli genre artiq movcuddur.");
                return View();
            }
            _context.Authors.FirstOrDefault(x => x.Id == author.Id).Name = author.Name;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Author author)
        {
            if (!ModelState.IsValid) { return View(); }
            if (_context.Authors.FirstOrDefault(x => x.Name == author.Name) != null)
            {
                ModelState.AddModelError("Name", "Bu adli genre artiq movcuddur");
                return View();
            }
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (_context.Authors.FirstOrDefault(x => x.Id == id) == null)
            {
                return RedirectToAction("Error");
            }
            _context.Authors.Remove(_context.Authors.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }

    }
}
