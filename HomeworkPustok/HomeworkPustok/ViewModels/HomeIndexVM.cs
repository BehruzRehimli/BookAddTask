using HomeworkPustok.Models;

namespace HomeworkPustok.ViewModels
{
    public class HomeIndexVM
    {
        public List<Slider> Slider { get; set; }
        public List<Book> FeatureBooks { get; set; }
        public List<Book> MostPopularBooks { get; set; }
        public List<Book> LastBooks { get; set; }


    }
}
