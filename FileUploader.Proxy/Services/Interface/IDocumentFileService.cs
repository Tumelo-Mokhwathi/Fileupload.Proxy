using FileUploader.Proxy.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.Proxy.Services.Interface
{
    public interface IDocumentFileService
    {
        DocumentFiles[] GetAllFiles();
        IFormFile CreateFile(IFormFile file);
    }
}
