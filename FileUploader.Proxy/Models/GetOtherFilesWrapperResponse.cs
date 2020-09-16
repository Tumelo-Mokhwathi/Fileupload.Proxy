using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FileUploader.Proxy.Models
{
    public class GetOtherFilesWrapperResponse
    {
        public HttpStatusCode code { get; set; }
        public OtherFiles[] file { get; set; }
        public string source { get; set; }

        public GetOtherFilesWrapperResponse(HttpStatusCode Code, OtherFiles[] File, string Source)
        {
            code = Code;
            file = File;
            source = Source;
        }
    }
}
