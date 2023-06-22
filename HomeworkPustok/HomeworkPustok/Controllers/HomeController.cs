using HomeworkPustok.DAL;
using HomeworkPustok.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HomeworkPustok.Controllers
{
    public class HomeController : Controller
    {
        readonly PustokDbContext _context;
        public HomeController(PustokDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            HomeIndexVM data= new HomeIndexVM() {
                Slider=_context.Sliders.ToList(),
                FeatureBooks=_context.Books.Include(x=>x.Author).Include(x=>x.Genre).Include(x=>x.Images).Where(y=>y.IsFeature==true).ToList(),
                LastBooks= _context.Books.Include(x => x.Author).Include(x => x.Genre).Include(x => x.Images).OrderBy(y => y.RewardPoint).Take(12).ToList(),
                MostPopularBooks= _context.Books.Include(x => x.Author).Include(x => x.Genre).Include(x => x.Images).Where(y => y.IsFeature == false).ToList(),
            };
            return View(data);
        }

        public IActionResult Detail()
        {
            return View();
        }

    }
}