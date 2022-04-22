using AlmassarGateApi.Domain.DTO.AddDTO;
using AlmassarGateApi.Domain.DTO.LookupsDTO;
using AlmassarGateApi.Domain.SearchModels;
using Domains.DTO;
using Domains.SearchModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace AlmassarGateApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironmen;
        public FileController(IWebHostEnvironment webHostEnvironmen)
        {
            _webHostEnvironmen = webHostEnvironmen;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Download([FromQuery] string file)
        {
            var uploads = Path.Combine(_webHostEnvironmen.WebRootPath,"home\\appfiles");
            var filePath = Path.Combine(uploads, file);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), file);
        }
        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

    }
}
