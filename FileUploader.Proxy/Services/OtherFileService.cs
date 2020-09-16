using FileUploader.Proxy.Models;
using FileUploader.Proxy.Services.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.Proxy.Services
{
    public class OtherFileService : IOtherFileService
    {
        private readonly FileUploaderContext _context;

        public OtherFileService(FileUploaderContext context)
        {
            _context = context;
        }

        public OtherFiles[] GetAllFiles()
        {
            var allFiles = (from file in _context.OtherFiles select file).ToArray();
            return allFiles;
        }

        public IFormFile CreateFile(IFormFile file)
        {
            var supportedTypes = new[] { "zip", "rar", "tgz" };

            var fileName = System.IO.Path.GetFileName(file.FileName);

            var fileExtension = System.IO.Path.GetExtension(file.FileName).Substring(1);

            using (var stream = new System.IO.MemoryStream())
            {
                file.CopyTo(stream);

                if (!supportedTypes.Contains(fileExtension))
                {
                    throw new NotSupportedException("Unsupported File Format");
                }

                var otherFile = new OtherFiles()
                {
                    FileId = 0,
                    FileName = fileName,
                    FileType = file.ContentType,
                    OtherFile = stream.ToArray(),
                    CreatedOn = DateTime.Now
                };

                _context.OtherFiles.Add(otherFile);
                _context.SaveChanges();
            }

            return file;
        }
    }
}
