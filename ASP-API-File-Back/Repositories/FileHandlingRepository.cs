using FileHandlingLibrary;

namespace ASP_API_File_Back.Repositories
{
    public class FileHandlingRepository
    {
        public string directoryPath = Directory.GetCurrentDirectory() + "/www/Files/";
        private FileHandling _fileLibrary;

        public FileHandling FileWork
        {
            get { return _fileLibrary; }
            set { _fileLibrary = value; }
        }

        public FileHandlingRepository()
        {
            
            if(_fileLibrary == null)
            {
                _fileLibrary = new FileHandling();
            }

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
