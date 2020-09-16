using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FileUploader.Proxy.Models
{
    public class GetDocumentFilesWrapperResponse
    {
        public HttpStatusCode code { get; set; }
        public DocumentFiles[] file { get; set; }
        public string source { get; set; }

        public GetDocumentFilesWrapperResponse(HttpStatusCode Code, DocumentFiles[] File, string Source)
        {
            code = Code;
            file = File;
            source = Source;
        }
    }
}
