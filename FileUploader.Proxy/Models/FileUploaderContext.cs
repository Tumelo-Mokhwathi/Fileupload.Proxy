using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.Proxy.Models
{
    public class FileUploaderContext : DbContext
    {
        public FileUploaderContext(DbContextOptions<FileUploaderContext> options) : base(options)
        {
        }
        public DbSet<DocumentFiles> DocumentFiles { get; set; }
        public DbSet<ImageFiles> ImageFiles { get; set; }
        public DbSet<OtherFiles> OtherFiles { get; set; }
    }
}
