using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.Proxy.Models
{
    public class ImageFiles 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }
        public string FileName { get; set; }

        public byte[] ImageFile { get; set; }

        [FileExtensions(Extensions = "jpg|jpeg|png|tiff")]
        public string FileType { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
