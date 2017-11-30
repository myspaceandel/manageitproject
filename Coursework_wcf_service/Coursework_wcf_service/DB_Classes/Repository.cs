using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursework_wcf_service.DB_Classes
{
    [Serializable]
    public class Repository
    {
        public List<Repository> repository;
        public List<MyFile> files;
        public string uri;
        public uint size;

        public Repository()
        {
            repository = new List<Repository>();
            files = new List<MyFile>();
            uri = "";
            size = 0;
        }
    }
}