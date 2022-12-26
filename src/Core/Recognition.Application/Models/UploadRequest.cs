using Recognition.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Models
{
    public class UploadRequest
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public UploadType UploadType { get; set; }
        public string Folder { get; set; }
        public byte[] Data { get; set; }

        public bool Overwrite { get; set; } = false;
    }
}
