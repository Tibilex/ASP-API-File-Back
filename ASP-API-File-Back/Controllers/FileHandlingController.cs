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
           
            /*
            if (file.Length > 0)
            {
                var filePath = $".//Files//{Path.GetRandomFileName()}.{new FileInfo(file.FileName).Extension}";

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return Ok();
            */
        }
    }
}