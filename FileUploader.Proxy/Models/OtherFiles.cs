using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.Proxy.Models
{
    public class OtherFiles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }
        public string FileName { get; set; }

        [FileExtensions(Extensions = "zip|rar|tgz")]
        public byte[] OtherFile { get; set; }
        public string FileType { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
