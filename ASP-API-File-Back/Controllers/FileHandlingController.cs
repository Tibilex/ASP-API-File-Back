using ASP_API_File_Back.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_API_File_Back.Controllers
{
    [ApiController]
    [Route("controller")]
    public class FileHandlingController : Controller
    {
        private FileHandlingRepository m_fileRepo;

        public FileHandlingController()
        {
            m_fileRepo = new();
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            if (!m_fileRepo.FileWork.UploadFile(file, m_fileRepo.directoryPath))
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("GetAllFiles")]
        public IEnumerable<string> GetAllFileNames() => m_fileRepo.FileWork.GetAllFilesNames(m_fileRepo.directoryPath);

        [HttpGet("GetFileByName")]
        public string GetAllFileNames(string fileName) => m_fileRepo.FileWork.GetFileByName(fileName, m_fileRepo.directoryPath);

        [HttpGet("GetFileByDate")]
        public string GetFileByDate(DateTime date) => m_fileRepo.FileWork.GetFileByDate(date, m_fileRepo.directoryPath);

        [HttpGet("DownloadFile")]
        public IActionResult GetBlobDownload([FromQuery] string name)
        {
            var net = new System.Net.WebClient();
            var data = net.DownloadData(m_fileRepo.directoryPath + name);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            var fileName = "something.bin";
            return File(content, contentType, fileName);
        }
    }
}