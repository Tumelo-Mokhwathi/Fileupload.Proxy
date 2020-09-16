using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FileUploader.Proxy.Models;
using FileUploader.Proxy.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using File = FileUploader.Proxy.Models.ImageFiles;

namespace FileUploader.Proxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageFileController : ControllerBase
    {
        private readonly IImageFileService _IFileService;

        public ImageFileController(IImageFileService fileService)
        {
            _IFileService = fileService;
        }

        [HttpGet("GetImageFiles")]
        public ActionResult<GetImageFilesWrapperResponse> GetImageFiles() 
        {
            var code = HttpStatusCode.OK;
            var files = _IFileService.GetAllFiles();
            var source = $"{Constants.Source.FilePrefixName}";

            try
            {
                return new GetImageFilesWrapperResponse(code, files, source);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("CreateImageFile"), DisableRequestSizeLimit]
        [Produces("application/json")]
        [Consumes("multipart/form-data")]
        public ActionResult<CreateFileWrapperResponse> CreateImageFile([FromForm(Name = "ImageFile")] IFormFile ImageFile)
        {
            var code = HttpStatusCode.OK;
            var files = _IFileService.CreateFile(ImageFile);
            var source = $"{Constants.Source.FilePrefixName}"; 

            try
            {
                return new CreateFileWrapperResponse(code, files, source);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}