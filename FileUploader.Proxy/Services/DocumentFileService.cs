using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUploader.Proxy.Models;
using FileUploader.Proxy.Services.Interface;
using Microsoft.AspNetCore.Http;

namespace FileUploader.Proxy.Services
{
    public class DocumentFileService : IDocumentFileService
    {
        private readonly FileUploaderContext _context;

        public DocumentFileService(FileUploaderContext context)
        {
            _context = context;
        }

        public DocumentFiles[] GetAllFiles()
        {
            var allFiles = (from file in _context.DocumentFiles select file).ToArray();
            return allFiles;
        }

        public IFormFile CreateFile(IFormFile file)
        {
            var supportedTypes = new[] { "doc", "docx", "pdf", "ppt", "xls" };

            var fileName = System.IO.Path.GetFileName(file.FileName);

            var fileExtension = System.IO.Path.GetExtension(file.FileName).Substring(1);

            using (var stream = new System.IO.MemoryStream())
            {
                file.CopyTo(stream);

                if (!supportedTypes.Contains(fileExtension))
                {
                    throw new NotSupportedException("Unsupported File Format");
                }

                var document = new DocumentFiles()
                {
                    FileId = 0,
                    FileName = fileName,
                    FileType = file.ContentType,
                    DocumentFile = stream.ToArray(),
                    CreatedOn = DateTime.Now
                };

                _context.DocumentFiles.Add(document);
                _context.SaveChanges();
            }

            return file;
        }
    }
}
