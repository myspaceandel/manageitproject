using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDropBox
{
    public partial class Test : Form
    {
        DirectoryController _controller;
        string[] extensions = {".avi", ".3gp", ".7z", ".ace", ".ai", ".aif", ".amr", ".asx", ".bat", ".bmp",
                               ".bup", ".cub", ".cbr", ".cda", ".cdl", ".cdr", ".chm",  ".dat", ".divx",".dll",
                               ".dmg", ".doc", ".dss", ".dvf", ".eps", ".exe", ".gif", ".html", ".indd",".jpeg",
                               ".jpg",".log", ".mp4", ".ogg", ".ppt", ".ps", ".psd", ".rm", ".rtf",".ss", ".swf",
                               ".tga", ".tif", ".tiff", ".tor", ".txt", ".vcd", ".wpd", ".xtm", ".zip"
                              };
        public Test()
        {
            InitializeComponent();

            listView1.SmallImageList = imageList1;
            listView1.LargeImageList = imageList1;



            _controller = new DirectoryController(@"D:\Cursova");

            OpenDirectory("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri(@"D:\Cursova");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(webBrowser1.CanGoBack)
            webBrowser1.GoBack();
            
        }


        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string path = listView1.SelectedItems[0].Text;
            OpenDirectory(path);
        }      
        private void OpenDirectory(string path)
        {
            try
            {
                string pathBefor = _controller.CurrentDirectory;
                string newPath = _controller.AddDirectoryAndGetPath(path);
                string checkPath = newPath.Remove(newPath.Length - 1);
                if (System.IO.File.Exists(checkPath))
                {
                    var fileToOpen = checkPath;
                    var process = new Process();
                    process.StartInfo = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        FileName = fileToOpen
                    };

                    process.Start();
                   

                    _controller.CurrentDirectory = pathBefor;
                }
                else
                {
                    listView1.Items.Clear();
                    ShowDirectoriesInListView(newPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowDirectoriesInListView(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);

            DirectoryInfo parent = info.Parent;
           // MessageBox.Show(parent.FullName);
           
            if (parent != null)
            {
                listView1.Items.Add(new System.Windows.Forms.ListViewItem("...", 51));
            }

            FileInfo[] fileAll = info.GetFiles();
            foreach (DirectoryInfo dInfo in info.GetDirectories())
            {
                listView1.Items.Add(new System.Windows.Forms.ListViewItem(dInfo.Name, 51));
            }

            assignIcons(fileAll);



        }
        private void assignIcons(FileInfo[] files)
        {

            foreach (FileInfo currentFile in files)
            {
                for (int i = 0; i < extensions.Length; i++)
                {
                    if (currentFile.FullName.EndsWith(extensions[i]))
                    {
                        listView1.Items.Add(currentFile.Name, i);
                        break;
                    }
                    if (currentFile.FullName.EndsWith(".MP3") || currentFile.FullName.EndsWith(".mp3"))
                    {
                        listView1.Items.Add(currentFile.Name, 0);
                        break;
                    }
                    if (i == (extensions.Length - 1))
                    {
                        listView1.Items.Add(currentFile.Name, 50);

                    }

                }
            }

        }

    }

    
}
