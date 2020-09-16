using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FileUploader.Proxy.Models
{
    public class GetImageFilesWrapperResponse
    {
        public HttpStatusCode code { get; set; }
        public ImageFiles[] file { get; set; }
        public string source { get; set; }

        public GetImageFilesWrapperResponse(HttpStatusCode Code, ImageFiles[] File, string Source)
        {
            code = Code;
            file = File;
            source = Source;
        }
    }
}
