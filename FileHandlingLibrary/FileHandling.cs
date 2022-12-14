using Microsoft.AspNetCore.Http;
using System.Web.Mvc;

namespace FileHandlingLibrary
{
    public class FileHandling
    {
        public bool UploadFile(IFormFile file, string path)
        {
            if (file.Length > 0)
            {
                var randomFileName = Path.GetRandomFileName().Replace(".", string.Empty);
                var filePath = $"{path}{randomFileName}{new FileInfo(file.FileName).Extension}";

                using (var stream = File.Create(filePath))
                {
                    file.CopyToAsync(stream);
                    return true;
                }
            }
            else 
            {  
                return false; 
            }
        }

        public IEnumerable<string> GetAllFilesNames(string path)
        {
            return new DirectoryInfo(path).GetFiles().Select(x => x.Name);
        }

        public string GetFileByName(string fileName, string path)
        {
            if(fileName != null)
            {
                List<string> fileNames = new();
                Directory.GetFiles(path, "*", SearchOption.AllDirectories)
                    .ToList()
                    .ForEach(x => fileNames.Add(Path.GetFileName(x)));

                if(fileNames.Count == 0) { return "Files Directory is empty"; }
                else
                {
                    foreach(var file in fileNames)
                    {
                        if (file == fileName) 
                        { 
                            return file; 
                        }
                    }
                    return "File Not Found";
                }
            }
            else
            {
                return "File Not Found";
            }
        }

        public string GetFileByDate(DateTime date, string path)
        {
            var directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();

            foreach(var file in files)
            {
                if (file.CreationTime.Date == date)
                {
                    return file.Name;
                }
            }
            return "File Not Found";
        }
    }
}