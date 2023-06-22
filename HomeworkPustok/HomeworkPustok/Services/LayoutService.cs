using HomeworkPustok.DAL;
using HomeworkPustok.Models;
using HomeworkPustok.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HomeworkPustok.Services
{
    public class LayoutService
    {
        private readonly PustokDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutService(PustokDbContext context, IHttpContextAccessor httpContextAssessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAssessor;
        }

        public List<Genre> GetGenre()
        {
            return _context.Genres.ToList();
        }
        public Dictionary<string, string> GetSettings() { return _context.Settings.ToDictionary(x=>x.Key,x=>x.Value);}

        public List<BasketPartialVM> GetBasketData()
        {
            var basketstr = _httpContextAccessor.HttpContext.Request.Cookies["basket"];
            var basketdata = new List<BasketStringVM>();

            if (basketstr != null)
            {
                basketdata = JsonConvert.DeserializeObject<List<BasketStringVM>>(basketstr);
            }

            var partialdata = new List<BasketPartialVM>();

            foreach (var item in basketdata)
            {
                var data = new BasketPartialVM()
                {
                    Count = item.Count,
                    Book = _context.Books.Include(x => x.Images).FirstOrDefault(x => x.Id == item.BookId)
                };
                partialdata.Add(data);
            }
            return partialdata;
        }
    }
}
