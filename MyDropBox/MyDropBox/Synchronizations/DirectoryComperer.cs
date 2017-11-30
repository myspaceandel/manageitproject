using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDropBox
{
    class DirectoryComparer : IEqualityComparer<DirectoryInfo>
    {
        #region IEqualityComparer<DirectoryInfo> Members

        public bool Equals(DirectoryInfo x, DirectoryInfo y)
        {
            return StringComparer.OrdinalIgnoreCase.Equals(x.Name, y.Name);
        }

        public int GetHashCode(DirectoryInfo obj)
        {
            return obj.Name.ToLower().GetHashCode();
        }

        #endregion
    }
}