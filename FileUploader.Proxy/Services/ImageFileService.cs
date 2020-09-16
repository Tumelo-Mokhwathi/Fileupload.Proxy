using FileUploader.Proxy.Models;
using FileUploader.Proxy.Services.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.Proxy.Services
{
    public class ImageFileService : IImageFileService
    {
        private readonly FileUploaderContext _context;

        public ImageFileService(FileUploaderContext context)
        {
            _context = context;
        }

        public ImageFiles[] GetAllFiles()
        {
            var allFiles = (from file in _context.ImageFiles select file).ToArray();
            return allFiles;
        }

        public IFormFile CreateFile(IFormFile file)
        {
            var supportedTypes = new[] { "jpg", "jpeg", "png", "tiff" };

            var fileName = System.IO.Path.GetFileName(file.FileName);

            var fileExtension = System.IO.Path.GetExtension(file.FileName).Substring(1);

            using (var stream = new System.IO.MemoryStream())
            {
                file.CopyTo(stream);

                if (!supportedTypes.Contains(fileExtension))
                {
                    throw new NotSupportedException("Unsupported File Format");
                }

                var image = new ImageFiles()
                {
                    FileId = 0,
                    FileName = fileName,
                    FileType = file.ContentType,
                    ImageFile = stream.ToArray(),
                    CreatedOn = DateTime.Now
                };

                _context.ImageFiles.Add(image);
                _context.SaveChanges();
            }       

            return file;
        }
    }
}
