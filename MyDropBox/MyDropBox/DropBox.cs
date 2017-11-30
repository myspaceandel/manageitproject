using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MyDropBox.ServiceReference1;
using System.ServiceModel.Security;
using System.ServiceModel;
using System.Threading;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace MyDropBox
{
    public partial class DropBox : Form
    {
        public string login;
        public string password;
        public bool isExit = false;
        private TransferServiceClient service;
        Client client;
        Thread sync = null;
        public delegate void RebuildInfo();
        public RebuildInfo myDelegate;

        DirectoryController _controller;

        string[] extensions = {".avi", ".3gp", ".7z", ".ace", ".ai", ".aif", ".amr", ".asx", ".bat", ".bmp",
                               ".bup", ".cub", ".cbr", ".cda", ".cdl", ".cdr", ".chm",  ".dat", ".divx",".dll",
                               ".dmg", ".doc", ".dss", ".dvf", ".eps", ".exe", ".gif", ".html", ".indd",".jpeg",
                               ".jpg",".log", ".mp4", ".ogg", ".ppt", ".ps", ".psd", ".rm", ".rtf",".ss", ".swf",
                               ".tga", ".tif", ".tiff", ".tor", ".txt", ".vcd", ".wpd", ".xtm", ".zip"
                              };
        string clientRoot;
        private void Login()
        {
            try
            {
                service = new TransferServiceClient();
                service.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                service.ClientCredentials.UserName.UserName = login;
                service.ClientCredentials.UserName.Password = password;

                client = service.GetClient(login);

                DirectoryInfo rootDir = service.GetRootRepository(client);


                clientRoot = CheckForFirsSing(rootDir);

                _controller.CurrentDirectory = clientRoot;

                OpenDirectory("");


                if(sync != null)
                {
                    try
                    {
                        sync.Abort();
                    }
                    catch { }
                }

                string path = @"D:\Cursova\DropBox\" + client.login;

                sync = new Thread(() => SyncFunction(path, service, client));
                sync.IsBackground = true;
                sync.Start();

            }
            catch
            {
                MessageBox.Show("uncorrect data please try again");
                if (!isExit)
                {
                    AuthenticationApplication app = new AuthenticationApplication(this);
                    app.ShowDialog();
                    Login();
                }
                else
                    Application.Exit();
            }
        }
        public DropBox()
        {
            InitializeComponent();

            listView1.SmallImageList = imageList1;
            listView1.LargeImageList = imageList1;

            listView1.DragOver += FileAttributeChanger_DragOver;
            listView1.DragDrop += FileAttributeChanger_DragDrop;

            _controller = new DirectoryController("");

            AuthenticationApplication authenticationApp = new AuthenticationApplication(this);
            authenticationApp.ShowDialog();

            Login();

            //string path = @"D:\Cursova\DropBox\" + client.login;

            //sync = new Thread(() => SyncFunction(path, service, client));
            //sync.IsBackground = true;
            //sync.Start();
        }

        void SyncFunction(string pathClient,TransferServiceClient service , Client client)
        {
            while(true)
            {
                DirectoryInfo clientInfo = new DirectoryInfo(pathClient);
                Synchronizer.SyncFolders(clientInfo, service.GetRootRepository(client));
            }
        }

        private void Download(string uploadFolder)
        {

            DownloadRequest uploadRequestInfo = new DownloadRequest();

            //uploadRequestInfo.FileName = treeView1.SelectedNode.FullPath;

            uploadRequestInfo.FileName = @"D:\Cursova\Clients\mykhailo\folder2\20140412_221449.mp4";

            RemoteFileInfo request = new RemoteFileInfo();

            request.Length = service.DownloadFile(ref uploadRequestInfo.FileName, out request.FileName, out request.FileByteStream);


            FileStream targetStream = null;
            Stream sourceStream = request.FileByteStream;


            if (String.IsNullOrEmpty(uploadFolder))
                uploadFolder = @"D:\Cursova\";




            string filePath = Path.Combine(uploadFolder, Path.GetFileName(request.FileName));

            using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                const int bufferLen = 65000;
                byte[] buffer = new byte[bufferLen];
                int count = 0;
                while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                {
                    targetStream.Write(buffer, 0, count);
                }
                targetStream.Close();
                sourceStream.Close();
            }

            MessageBox.Show("download completed");
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region remove using treeview
            //if (treeView1.SelectedNode.FullPath.Contains('.'))
            //{
            //    service.DeleteFile(treeView1.SelectedNode.FullPath);
                
            //    treeView1.Nodes.Remove(treeView1.SelectedNode);
            //}
            //else
            //{
            //    string str = service.DeleteFolder(treeView1.SelectedNode.FullPath);

            //    if (str.Equals("Directory deleted"))
            //    treeView1.Nodes.Remove(treeView1.SelectedNode);
            //}
            #endregion

            try
            {
                if (File.Exists(_controller.CurrentDirectory+listView1.SelectedItems[0].Text))
                {
                    string str = _controller.CurrentDirectory + listView1.SelectedItems[0].Text;
                    File.Delete(Path.Combine(str));
                    str = str.Replace("DropBox", "Clients");
                    service.DeleteFile(str);


                    ShowDirectoriesInListView(_controller.CurrentDirectory);   
                }
                else
                {

                    string str = _controller.CurrentDirectory + listView1.SelectedItems[0].Text;
                    Directory.Delete(Path.Combine(str), true);
                    str = str.Replace("DropBox", "Clients");
                    service.DeleteFolder(str);

                    ShowDirectoriesInListView(_controller.CurrentDirectory);   

                   
                }
            }
            catch
            {

            }
        }
      
        

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.DeleteAccount(client);

            AuthenticationApplication authenticationApp = new AuthenticationApplication(this);
            authenticationApp.ShowDialog();

            listView1.Clear();

            Login();
        }

        private void createFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region createFolder UsingtreeView
            //string inputValue = Interaction.InputBox("Hi "+client.name, "Please input folder name", "");

            //string str = ("\\" + treeView1.SelectedNode.FullPath + "\\" + inputValue);

            //str = str.Substring(1, str.Length-1);
           
            //service.CreateFolder(str);

            //treeView1.SelectedNode.Nodes.Add(inputValue);
            #endregion

            string inputValue = Interaction.InputBox("Hi " + client.name, "Please input folder name", "");

            Directory.CreateDirectory(_controller.CurrentDirectory + inputValue);

            ShowDirectoriesInListView(_controller.CurrentDirectory); 

        }

        private void DeleteFromService()
        {
            string pathClient = @"D:\Cursova\DropBox\" + client.login;
            DirectoryInfo clientInfo = new DirectoryInfo(pathClient);

            DirectoryInfo serviceInfo = service.GetRootRepository(client);




         //   Synchronizer.SyncFolders(clientInfo, service.GetRootRepository(client));
        }



        public void SyncFiles(DirectoryInfo serviceInfo, DirectoryInfo clientInfo = null)
        {
            if (clientInfo == null && Directory.Exists(serviceInfo.FullName))
            {
                service.DeleteFolder(serviceInfo.FullName);
                return;
            }
            if (Directory.Exists(serviceInfo.FullName) && serviceInfo.Name == clientInfo.Name && !Directory.Exists(clientInfo.FullName))
            {
                service.DeleteFolder(serviceInfo.FullName);
            }
            else
            {

                foreach (FileInfo f in serviceInfo.GetFiles())
                {
                    try
                    {
                        if (File.Exists(serviceInfo.FullName + '\\' + f.Name) && !File.Exists(clientInfo.FullName + '\\' + f.Name))
                            service.DeleteFile(serviceInfo.FullName + '\\' + f.Name);
                    }
                    catch { }
                }

                DirectoryInfo[] clInfoArr = clientInfo.GetDirectories();
             foreach ( DirectoryInfo dirInfo in serviceInfo.GetDirectories())
             {
                 SyncFiles(dirInfo, clInfoArr.ToList().Where(x => x.Name == dirInfo.Name).Select(x => x).First());
             }



            }
        }
    
        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region upload treeview
            //if (!string.IsNullOrEmpty(treeView1.SelectedNode.FullPath))
            //{
            //    string path;
            //    if (treeView1.SelectedNode.FullPath.Contains('.'))
            //    {
            //        path = treeView1.SelectedNode.Parent.FullPath + "\\";
            //    }
            //    else
            //    {
            //        path = treeView1.SelectedNode.FullPath + "\\";
            //    }
              
            //    string folderPath = "";
            //    OpenFileDialog filedlg = new OpenFileDialog();
            //    if (filedlg.ShowDialog() == DialogResult.OK)
            //    {
            //        folderPath = filedlg.FileName;
            //    }
            //    if (!String.IsNullOrEmpty(folderPath))
            //    {
            //        myDelegate = new RebuildInfo(RebuildMethod);
            //        Thread downloadThread = new Thread(() => Upload(folderPath,path,this));
            //        downloadThread.IsBackground = true;
            //        downloadThread.Start();
            //    }
            //}
            #endregion

            string folderPath = "";
            OpenFileDialog filedlg = new OpenFileDialog();
            if (filedlg.ShowDialog() == DialogResult.OK)
            {
                folderPath = filedlg.FileName;
            }
            if (!String.IsNullOrEmpty(folderPath))
            {

                int ix = _controller.CurrentDirectory.IndexOf(client.login);
                string serverPath = _controller.CurrentDirectory;
                if (ix != -1)
                {
                    serverPath = _controller.CurrentDirectory.Substring(ix);
                }


                //File.Create(_controller.CurrentDirectory + Path.GetFileName(folderPath));
                //File.Copy(folderPath, _controller.CurrentDirectory + Path.GetFileName(folderPath), true);

                myDelegate = new RebuildInfo(RebuildMethod);
                Thread downloadThread = new Thread(() => Upload(folderPath, serverPath, this));
                downloadThread.IsBackground = true;
                downloadThread.Start();
            }
        }
        private void RebuildMethod()
        {
            ShowDirectoriesInListView(_controller.CurrentDirectory);
        }

      
        private void Upload(string uploadFilePath,string PathForServer, DropBox box)
        {
            try
            {
                using (System.IO.FileStream stream = new System.IO.FileStream(uploadFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    ServiceReference1.RemoteFileInfo uploadRequestInfo = new RemoteFileInfo();
                    uploadRequestInfo.FileName = Path.GetFileName(uploadFilePath);
                    uploadRequestInfo.Length = stream.Length;
                    uploadRequestInfo.FileByteStream = stream;
                    if (Convert.ToDouble(service.GetDiskSize(client).Split(' ')[1]) - (stream.Length / Math.Pow(1024, 3)) < 0)
                    {
                        MessageBox.Show("not enough memory to disk");
                        return;
                    }
                    //  MessageBox.Show(service.Endpoint.Address.ToString());

                    service.UploadFile(uploadRequestInfo.FileName, uploadRequestInfo.Length, PathForServer, uploadRequestInfo.FileByteStream);

                    box.Invoke(box.myDelegate);
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string uploadFolder="";
                
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(fbd.SelectedPath))
                        uploadFolder = fbd.SelectedPath;
                }

                Thread downloadThread = new Thread(() => Download(uploadFolder));
                downloadThread.IsBackground = true;
                downloadThread.Start();                
        }

        #region oldInterface using treeview
        //private void FillTree(DirectoryInfo rootDir, TreeNode parentNode)
        //{
        //    if (rootDir != null)
        //    {
        //        foreach (DirectoryInfo dir in rootDir.GetDirectories())
        //        {
        //            TreeNode node = new TreeNode();
        //            node.Text = dir.Name;
        //            node.Nodes.Add("");
        //            parentNode.Nodes.Add(node);
        //            node.Nodes[0].Remove();
        //            FillTree(dir, node);
        //        }

        //        foreach (FileInfo file in rootDir.GetFiles())
        //        {
        //            TreeNode node = new TreeNode();
        //            node.Text = file.Name;
        //            node.ImageIndex = 2;
        //            node.SelectedImageIndex = 2;
        //            parentNode.Nodes.Add(node);
        //        }
        //    }
        //}
        //public void RebuildMethod()
        //{
        //    treeView1.Nodes.Clear();

        //    DirectoryInfo rootDir = service.GetRootRepository(client);

        //    TreeNode parentNode = new TreeNode(client.login);
        //    treeView1.Nodes.Add(parentNode);
        //    FillTree(rootDir, parentNode);
        //}
        #endregion

        private void infoAboutMyBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = service.GetDiskSize(client).Split(' ');
            MessageBox.Show("Your disk size is 1GB. busy place is " + str[0] + ". Free place is " + str[1]);
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It is my simple drop box");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void reloginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthenticationApplication authenticationApp = new AuthenticationApplication(this);
            authenticationApp.ShowDialog();

            Login();
        }



        /// <summary>
        /// New interface using listView
        /// </summary>
        private void listView1_DoubleClick(object sender, EventArgs e)
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
                    ShowDirectoriesInListView(Path.Combine(newPath));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowDirectoriesInListView(string path)
        {
            listView1.Clear();

            DirectoryInfo info = new DirectoryInfo(path);

            DirectoryInfo parent = info.Parent;

            if (parent != null && info.FullName != (client.rootDirectory + Path.DirectorySeparatorChar) && info.FullName != (clientRoot + Path.DirectorySeparatorChar))
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

        private string CheckForFirsSing(DirectoryInfo clientInfo)
        {
            DirectoryCopy(clientInfo, @"D:\Cursova\DropBox\" + client.login, true);
            return @"D:\Cursova\DropBox\" + client.login;
        }
        private void DownLoad(string folder, string file)
        {
            try
            {
                DownloadRequest uploadRequestInfo = new DownloadRequest();

                uploadRequestInfo.FileName = file;

                RemoteFileInfo request = new RemoteFileInfo();

                request.Length = service.DownloadFile(ref uploadRequestInfo.FileName, out request.FileName, out request.FileByteStream);


                FileStream targetStream = null;
                Stream sourceStream = request.FileByteStream;


                if (String.IsNullOrEmpty(folder))
                    folder = @"D:\Cursova\";

                string filePath = Path.Combine(folder, Path.GetFileName(request.FileName));

                using (targetStream = new FileStream(folder, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    const int bufferLen = 65000;
                    byte[] buffer = new byte[bufferLen];
                    int count = 0;
                    while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                    {
                        targetStream.Write(buffer, 0, count);
                    }
                    targetStream.Close();
                    sourceStream.Close();
                }
            }
            catch(FaultException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        public void DirectoryCopy(DirectoryInfo sourceDirectory, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            //  DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            //if (!dir.Exists)
            //{
            //    throw new DirectoryNotFoundException(
            //        "Source directory does not exist or could not be found: "
            //        + sourceDirName);
            //}

            DirectoryInfo[] dirs = sourceDirectory.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = sourceDirectory.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                if (!File.Exists(temppath))
                {
                    Thread downloadThread = new Thread(() => DownLoad(temppath, file.FullName));
                    downloadThread.IsBackground = true;
                    downloadThread.Start();
                }
             
             //   file.CopyTo(temppath, false);
            }



            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir, temppath, copySubDirs);
                }
            }
        }

     
    #region DragFiles

        private void FileAttributeChanger_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            this.AllowDrop = true;
        }

        private void FileAttributeChanger_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in FileList)
            {
                if (File.GetAttributes(file).ToString().Contains("Directory"))
                {
                    DirectoryInfo di = new DirectoryInfo(file);
                    DirectoryLocalCopy(di, GetCurrencyFolderPath()+di.Name, true);
                }
                else
                {
                    FileInfo fi = new FileInfo(file);                 
                    File.Copy(fi.FullName, GetCurrencyFolderPath() + fi.Name);
                }
            }
            ShowDirectoriesInListView(_controller.CurrentDirectory);
        }

        private string GetCurrencyFolderPath()
        {
            return _controller.CurrentDirectory; ;
        }
        private void DirectoryLocalCopy(DirectoryInfo sourceDirectory, string destDirName, bool copySubDirs)
        {

            DirectoryInfo[] dirs = sourceDirectory.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            FileInfo[] files = sourceDirectory.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                if (!File.Exists(temppath))
                {
                    file.CopyTo(temppath, false);
                }
            }
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir, temppath, copySubDirs);
                }
            }
        }
    

    #endregion

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDirectoriesInListView(_controller.CurrentDirectory);

            SyncFiles(service.GetRootRepository(client), new DirectoryInfo(@"D:\Cursova\DropBox\" + client.login));
        }

        private void DropBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            SyncFiles(service.GetRootRepository(client), new DirectoryInfo(@"D:\Cursova\DropBox\" + client.login));
        }
    }
}



   //private void button1_Click(object sender, EventArgs e)
   //     {
   //         string firstLocation = @"D:\Cursova\Clients\qwe";
   //         string secondLocation = @"D:\Cursova\DropBox\qwe";

   //         SyncId sourceId = GetSyncID(@"D:\Cursova\Clients\qwe\File.ID");

   //         //Generate a unique Id for the destination and store it in a file
   //         //for future reference.
   //         SyncId destId = GetSyncID(@"D:\Cursova\DropBox\qwe\File.ID");


   //         Microsoft.Synchronization.Files.FileSyncProvider firstProvider = new FileSyncProvider(sourceId.GetGuidId(), firstLocation);
   //         FileSyncProvider secondProvider = new FileSyncProvider(destId.GetGuidId(), secondLocation);


   //         SyncAgent agent = new SyncAgent();

   //         //assign the source replica as the Local Provider and the
   //         //destination replica as the Remote provider so that the agent
   //         //knows which is the source and which one is the destination.
   //         agent.LocalProvider = firstProvider;
   //         agent.RemoteProvider = secondProvider;

   //         //Set the direction of synchronization from Source to destination
   //         //as this is a one way synchronization. You may use
   //         //SyncDirection.Download if you want the Local replica to be
   //         //treated as Destination and the Remote replica to be the source;
   //         //use SyncDirection.DownloadAndUpload or
   //         //SyncDirection.UploadAndDownload for two way synchronization.

   //         //agent.Direction = SyncDirection.Upload;

   //         //make a call to the Synchronize method for starting the
   //         //synchronization process.
   //         agent.Synchronize();
   //     }

 //private static SyncId GetSyncID(string syncFilePath)
 //       {
 //           Guid guid;
 //           SyncId replicaID = null;
 //           if (!File.Exists(syncFilePath)) //The ID file doesn't exist. 
 //           //Create the file and store the guid which is used to 
 //           //instantiate the instance of the SyncId.
 //           {
 //               guid = Guid.NewGuid();
 //               replicaID = new SyncId(guid);
 //               FileStream fs = File.Open(syncFilePath, FileMode.Create);
 //               StreamWriter sw = new StreamWriter(fs);
 //               sw.WriteLine(guid.ToString());
 //               sw.Close();
 //               fs.Close();
 //           }
 //           else
 //           {
 //               FileStream fs = File.Open(syncFilePath, FileMode.Open);
 //               StreamReader sr = new StreamReader(fs);
 //               string guidString = sr.ReadLine();
 //               guid = new Guid(guidString);
 //               replicaID = new SyncId(guid);
 //               sr.Close();
 //               fs.Close();
 //           }
 //           return (replicaID);
 //       }