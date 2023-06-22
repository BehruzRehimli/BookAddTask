using HomeworkPustok.Areas.Manage.ViewModels;
using HomeworkPustok.DAL;
using HomeworkPustok.Helpers;
using HomeworkPustok.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeworkPustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BookController : Controller
    {
        private readonly PustokDbContext _context;

        public IWebHostEnvironment _env { get; }

        public BookController(PustokDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            var books = _context.Books.Include(x => x.Genre).Include(x => x.Author).Include(x => x.Images.Where(x => x.PhotoNumber == 1));
            return View(PaginationMV<Book>.Create(books,page,4));
        }
        public IActionResult Add()
        {
            ViewBag.Authors=_context.Authors.ToList();
            ViewBag.Genres=_context.Genres.ToList();
            ViewBag.Tags=_context.Tags.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            ViewBag.Tags = _context.Tags.ToList();

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (book==null)
            {
                return View("error");
            }
            if (book.MainImage==null)
            {
                ModelState.AddModelError("MainImage", "MainImage is required!");
                return View();
            }
            if (book.SecondImage == null)
            {
                ModelState.AddModelError("SecondImage", "SecondImage is required!");
                return View();
            }
            if (_context.Genres.FirstOrDefault(x=>x.Id==book.GenreId)==null|| _context.Authors.FirstOrDefault(x => x.Id == book.AuthorId) == null)
            {
                return View("error");
            }
            _context.Books.Add(book);
            var mainimg = new BookImage() {
                Image = FileMeneger.UploadFile(_env.WebRootPath,"manage/upload/product",book.MainImage),
                PhotoNumber=1,
                Book=book
            };
            _context.Bookİmages.Add(mainimg);
            var secondimg = new BookImage()
            {
                Image = FileMeneger.UploadFile(_env.WebRootPath, "manage/upload/product", book.SecondImage),
                PhotoNumber=2,
                Book=book
            };
            _context.Bookİmages.Add(secondimg);

            foreach (var item in book.MoreImageis)
            {
                byte count = 2;
                var img = new BookImage()
                {
                    Image = FileMeneger.UploadFile(_env.WebRootPath, "manage/upload/product", item),
                    PhotoNumber = count,
                    Book = book
                };
                count++;
                _context.Bookİmages.Add(img);
            }
            foreach (int item in book.TagsIds)
            {
                var tag=_context.Tags.FirstOrDefault(x => x.Id == item);
                if (tag == null) return View("error");
                var booktag = new BookTag()
                {
                    Book = book,
                    Tag = tag
                };
                _context.BookTag.Add(booktag);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
