using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FileUploader.Proxy.Models
{
    public class CreateFileWrapperResponse
    {
        public HttpStatusCode code { get; set; }
        public IFormFile file { get; set; }
        public string source { get; set; }

        public CreateFileWrapperResponse(HttpStatusCode Code, IFormFile File, string Source)
        {
            code = Code;
            file = File;
            source = Source;
        }
    }
}
