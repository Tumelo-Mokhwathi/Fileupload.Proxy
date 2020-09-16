using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FileUploader.Proxy.Models;
using FileUploader.Proxy.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUploader.Proxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherFileController : ControllerBase
    {
        private readonly IOtherFileService _IOtherFileService; 

        public OtherFileController(IOtherFileService otherFileService)
        {
            _IOtherFileService = otherFileService;
        }

        [HttpGet("GetOtherFiles")]
        public ActionResult<GetOtherFilesWrapperResponse> GetOtherFiles()
        {
            var code = HttpStatusCode.OK;
            var files = _IOtherFileService.GetAllFiles();
            var source = $"{Constants.Source.FilePrefixName}";

            try
            {
                return new GetOtherFilesWrapperResponse(code, files, source);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("CreateOtherFile"), DisableRequestSizeLimit]
        [Produces("application/json")]
        [Consumes("multipart/form-data")]
        public ActionResult<CreateFileWrapperResponse> CreateOtherFile([FromForm(Name = "OtherFile")] IFormFile OtherFile)
        {
            var code = HttpStatusCode.OK;
            var files = _IOtherFileService.CreateFile(OtherFile);
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