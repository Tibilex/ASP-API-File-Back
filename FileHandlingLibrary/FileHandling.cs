using Microsoft.AspNetCore.Http;

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

        public bool DownloadFile(string fileName)
        {
            return false;
        }

        public IEnumerable<string> GetAllFilesNames(string path)
        {
            List<string> fileNames = new();
            Directory.GetFiles(path, "*", SearchOption.AllDirectories)
                .ToList()
                .ForEach(f => fileNames.Add(Path.GetFileName(f)));

            return fileNames;
        }

        public bool GetFileByName(string fileName)
        {
            return false;
        }

        public bool GetFileByDate(DateTime date)
        {
            return false;
        }
    }
}