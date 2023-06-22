using HomeworkPustok.Models;
using System.Xml.Linq;

namespace HomeworkPustok.Helpers
{
    public static class FileMeneger
    {
        public static string UploadFile(string filePath,string folder, IFormFile file)
        {
            var mainN = (file.FileName.Length > 60 ? Guid.NewGuid().ToString() + file.FileName.Substring(file.FileName.Length - 60) : Guid.NewGuid().ToString() + file.FileName);
            using (var stream = new FileStream(Path.Combine(filePath, folder, mainN), FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return mainN;
        }
        public static void DeleteFile(string filePath,string folder,string fileName) {
            var path = Path.Combine(filePath, folder,fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
