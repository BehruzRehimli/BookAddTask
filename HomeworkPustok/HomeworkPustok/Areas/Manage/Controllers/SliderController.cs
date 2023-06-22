using HomeworkPustok.DAL;
using HomeworkPustok.Models;
using Microsoft.AspNetCore.Mvc;
using HomeworkPustok.Helpers;

namespace HomeworkPustok.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly PustokDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(PustokDbContext context, IWebHostEnvironment env )
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var datas=_context.Sliders.ToList();
            return View(datas);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (slider==null)
            {
                return View("Error");
            }
            if (slider.ImageFile==null)
            {
                ModelState.AddModelError("ImageFile", "Slider-in image-i olmalidir!");
                return View();
            }

            slider.Image =FileMeneger.UploadFile(_env.WebRootPath,"manage/upload/slider",slider.ImageFile);
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var data=_context.Sliders.FirstOrDefault(x=>x.Id==id);
            if (data==null) View("Error");
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            if (slider == null) return View("Error");
            var changingData = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);
            if (changingData==null)
            {
                return View("error");
            }
            if (!ModelState.IsValid) return View(changingData);

            if (slider.ImageFile==null)
            {
                slider.ImageFile = changingData.ImageFile;
            }
            else
            {

                var removeImageName = changingData.Image;
                slider.Image = FileMeneger.UploadFile(_env.WebRootPath, "manage/upload/slider", slider.ImageFile);
                FileMeneger.DeleteFile(_env.WebRootPath, "manage/upload/slider", removeImageName);
            }
            changingData.Title1 = slider.Title1;
            changingData.Title2 = slider.Title2;
            changingData.Des= slider.Des;
            changingData.SlideLocation = slider.SlideLocation;
            changingData.Image= slider.Image;
            changingData.ImageFile= slider.ImageFile;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            _context.Sliders.Remove(_context.Sliders.FirstOrDefault(s => s.Id == id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
