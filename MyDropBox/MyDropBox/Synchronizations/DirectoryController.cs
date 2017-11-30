using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDropBox
{
    class DirectoryController
    {
        private string _currentDirectory;

        public string CurrentDirectory
        {
            get { return _currentDirectory; }
            set { _currentDirectory = value; }
        }

        public DirectoryController(string beginDirectory)
        {
            _currentDirectory = beginDirectory;
        }

        public string AddDirectoryAndGetPath(string path)
        {
            if (path.Equals("..."))
            {
                int lastIndex = _currentDirectory.Length;
                if (_currentDirectory.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    lastIndex = _currentDirectory.LastIndexOf(Path.DirectorySeparatorChar);
                    _currentDirectory = _currentDirectory.Remove(lastIndex);
                }
                lastIndex = _currentDirectory.LastIndexOf(Path.DirectorySeparatorChar) + 1;
                _currentDirectory = _currentDirectory.Remove(lastIndex);

            }
            else
            {
                _currentDirectory = string.Format("{0}{1}{2}", _currentDirectory, path, Path.DirectorySeparatorChar);
            }
            return _currentDirectory;
        }
    }
}
