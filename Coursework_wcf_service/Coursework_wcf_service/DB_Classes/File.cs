using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Coursework_wcf_service.DB_Classes
{
    [Serializable]
    public class MyFile
    {
        public string virtualPath;
        public uint size;
        public string fileExtension;
        public Stream fileStream;
    }
}