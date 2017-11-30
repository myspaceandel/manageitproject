using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDropBox
{
    public class Synchronizer
    {
        public static void SyncFolders(DirectoryInfo left, DirectoryInfo right)
        {
            SyncFiles(left, right);

            var comparer = new DirectoryComparer();

            var leftChildDirectories = left.GetDirectories();
            var rightChildDirectories = right.GetDirectories();

            leftChildDirectories.Except(rightChildDirectories, comparer).ToList()
                .ForEach(d => CopyFolder(d, right.CreateSubdirectory(d.Name)));
            rightChildDirectories.Except(leftChildDirectories, comparer).ToList()
                .ForEach(d => CopyFolder(d, left.CreateSubdirectory(d.Name)));

            leftChildDirectories.Intersect(rightChildDirectories, comparer).ToList()
                .ForEach(d => SyncFolders(d, new DirectoryInfo(Path.Combine(right.FullName, d.Name))));
        }

        public static void CopyFolder(DirectoryInfo source, DirectoryInfo target)
        {
            source.GetFiles().ToList()
                .ForEach(f => f.CopyTo(Path.Combine(target.FullName, f.Name)));
            source.GetDirectories().ToList()
                .ForEach(d => CopyFolder(d, target.CreateSubdirectory(d.Name)));
        }

        public static void SyncFiles(DirectoryInfo left, DirectoryInfo right)
        {
            if (Directory.Exists(right.FullName))
            {
                FileInfo[] infoRight = right.GetFiles();
                foreach (FileInfo f in left.GetFiles())
                {
                    try
                    {
                        if (File.Exists(right.FullName + '\\' + f.Name))
                        {
                            FileInfo fileInfo = right.GetFiles().Where(x => x.Name == f.Name).Select(x => x).First();
                            if (f.LastWriteTime != fileInfo.LastWriteTime)
                            {
                                if (File.Exists(fileInfo.FullName))
                                    f.CopyTo(fileInfo.FullName, true);
                                else
                                    File.Delete(right.FullName + '\\' + f.Name);
                            }
                        }
                        else
                        {
                            File.Create(right.FullName + '\\' + f.Name);
                            f.CopyTo(right.FullName + '\\' + f.Name, true);
                        }
                    }
                    catch { }
                }
            }
        }
    }
}
