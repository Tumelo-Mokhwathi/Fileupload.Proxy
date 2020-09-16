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
    public class DocumentFileController : ControllerBase
    {
        private readonly IDocumentFileService _IDocumentService; 

        public DocumentFileController(IDocumentFileService documentService) 
        {
            _IDocumentService = documentService;
        }

        [HttpGet("GetDocumentFiles")]
        public ActionResult<GetDocumentFilesWrapperResponse> GetDocumentFiles()
        {
            var code = HttpStatusCode.OK;
            var files = _IDocumentService.GetAllFiles();
            var source = $"{Constants.Source.FilePrefixName}";

            try
            {
                return new GetDocumentFilesWrapperResponse(code, files, source);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("CreateDocumentFile"), DisableRequestSizeLimit]
        [Produces("application/json")]
        [Consumes("multipart/form-data")]
        public ActionResult<CreateFileWrapperResponse> CreateDocumentFile([FromForm(Name = "DocumentFile")] IFormFile DocumentFile)
        {
            var code = HttpStatusCode.OK;
            var files = _IDocumentService.CreateFile(DocumentFile);
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