using HomeworkPustok.DAL;
using HomeworkPustok.Models;
using HomeworkPustok.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HomeworkPustok.Controllers
{
    public class BookController : Controller
    {
        private readonly PustokDbContext _context;

        public BookController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Detail(int id)
        {
            var data = _context.Books.Include(x=>x.Genre).Include(x=>x.BookTag).ThenInclude(x=>x.Tag).Include(x=>x.Author).Include(x=>x.Images.Where(x=>x.PhotoNumber==1)).FirstOrDefault(x => x.Id == id);
            return PartialView("_BookModalPartial",data);
        }

        public IActionResult AddBasket(int id) 
        {
            var basketstr=Request.Cookies["basket"];
            var basketdata =new  List<BasketStringVM>();
            if (basketstr==null) {
                var data = new BasketStringVM()
                {
                    BookId= id,
                    Count=1
                };
                basketdata.Add(data);
                Response.Cookies.Append("basket",JsonConvert.SerializeObject(basketdata));
            }
            else
            {
                basketdata=JsonConvert.DeserializeObject<List<BasketStringVM>>(basketstr);
                if (basketdata.FirstOrDefault(x => x.BookId == id) == null)
                {
                    var data = new BasketStringVM()
                    {
                        BookId = id,
                        Count = 1
                    };
                    basketdata.Add(data);
                    Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketdata));
                }
                else
                {
                    basketdata.FirstOrDefault(x => x.BookId == id).Count++;
                    Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketdata));
                }
            }

            var partialdata = new List<BasketPartialVM>();

            foreach (BasketStringVM item in basketdata)
            {
                var data = new BasketPartialVM()
                {
                    Book=_context.Books.Include(x=>x.Images.Where(x=>x.PhotoNumber==1)).FirstOrDefault(x=>x.Id== item.BookId),
                    Count=item.Count,
                };
                partialdata.Add(data);
            }

            return PartialView("_HomeBasketPartial",partialdata);
        }
        public IActionResult BasketDelete(int id)
        {
           var basketstr= Request.Cookies["basket"];
            var basketdata=JsonConvert.DeserializeObject<List<BasketStringVM>>(basketstr);
            basketdata.Remove(basketdata.FirstOrDefault(x=>x.BookId==id));
            Response.Cookies.Append("basket",JsonConvert.SerializeObject(basketdata));

            var partialdata=new List<BasketPartialVM>();
            foreach (var item in basketdata)
            {
                var data = new BasketPartialVM()
                {
                    Book = _context.Books.Include(x => x.Images).FirstOrDefault(x => x.Id == item.BookId),
                    Count = item.Count,
                };
                partialdata.Add(data);
            }
            return PartialView("_HomeBasketPartial", partialdata);
        }
    }
}
