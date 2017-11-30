using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using Coursework_wcf_service.MessageContrants;
using System.Data.SqlClient;
using Coursework_wcf_service.DB_Classes;

namespace Coursework_wcf_service
{
    public class SizeInfo
    {
        public static long GetSize(DirectoryInfo directory)
        {
            long size = 0;

            foreach (FileInfo f in directory.GetFiles())
            {
                size += f.Length;
            }

            foreach (DirectoryInfo directortInfo in directory.GetDirectories())
            {
                size += GetSize(directortInfo);
            }
            return size;
        }
    }
   // [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)] 
    public class File_Manager_Service : ITransferService, IRegistryContract
    {
        public string GetDiskSize(Client client)
        {
            long size = SizeInfo.GetSize(GetRootRepository(client));
            double gb = Math.Round((size / Math.Pow(1024, 3)),3);

            return "" + gb + " " + (1 - gb).ToString(); 

        }
        public RemoteFileInfo DownloadFile(DownloadRequest request)
        {
            RemoteFileInfo result = new RemoteFileInfo();
            try
            {
               
                string filePath = System.IO.Path.Combine(@"D:\Cursova\Clients\",request.FileName);
               // if (request.FileName.Contains("D:"))
               //     filePath = request.FileName;

                System.IO.FileStream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);


               // result.FileName = request.FileName;
                result.FileName = stream.Name;
                result.uploadFolder = request.FileName;
                result.Length = stream.Length;
                result.FileByteStream = stream;
            }
            catch (Exception ex)
            {

            }
            return result;

        }

        public void UploadFile(RemoteFileInfo request)
        {
            FileStream targetStream = null;
            Stream sourceStream = request.FileByteStream;

            DirectoryInfo dirinf = new DirectoryInfo(Path.Combine(@"D:\Cursova\Clients\", request.uploadFolder.Split('\\')[0]));
            long sizeInf = SizeInfo.GetSize(dirinf);
            sizeInf += request.Length;

            if ((sizeInf / Math.Pow(1024, 3)) >= 1)
            {
                return;
            }
            else
            {
                string filePath = Path.Combine(@"D:\Cursova\Clients\", request.uploadFolder, request.FileName);

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
                    return;
                }
            }
        }

        public string Registry(Client client)
        {
            try
            {
                SqlConnection con = new SqlConnection();


                con.ConnectionString = @"Server = МІША-ПК\SQLSERVER_CUB; Database=CourseworDotNet; User Id=sa; Password=1";
                con.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = con;


                SqlParameter name = new SqlParameter("@name", System.Data.SqlDbType.VarChar);

                SqlParameter surName = new SqlParameter("@surName", System.Data.SqlDbType.VarChar);

                SqlParameter login = new SqlParameter("@login", System.Data.SqlDbType.VarChar);

                SqlParameter password = new SqlParameter("@password", System.Data.SqlDbType.VarChar);

                SqlParameter date = new SqlParameter("@date", System.Data.SqlDbType.Date);

                SqlParameter rootDirectory = new SqlParameter("@rootDirectory", System.Data.SqlDbType.VarChar);

                string path = @"D:\Cursova\Clients\" + client.login;

                System.IO.Directory.CreateDirectory(path);

                rootDirectory.Value = path;

                name.Value = client.name;
                surName.Value = client.surname;
                login.Value = client.login;
                date.Value = client.birthDate.ToShortDateString();
                password.Value = client.password;

                command.Parameters.Add(name);
                command.Parameters.Add(surName);
                command.Parameters.Add(login);
                command.Parameters.Add(date);
                command.Parameters.Add(password);
                command.Parameters.Add(rootDirectory);

                command.CommandText = "select count(idClient) from Clients where Ilogin = @login";

                SqlDataReader reader = command.ExecuteReader();
                if (reader != null)
                {
                    reader.Read();
                    int count = (int)reader[0];
                    reader.Close();
                    if (count > 0)
                        return "this login is already selected";
                }
                else
                {
                    reader.Dispose();
                }

                command.CommandText = "insert into Clients values(@name,@surName,@password,@login,@date,@rootDirectory)";

                command.ExecuteNonQuery();
                return "You have successfully registered";
            }
            catch
            {
                return "error";
            }
        } // it work

        public DirectoryInfo GetRootRepository(Client client)
        {
            DirectoryInfo info = new DirectoryInfo(client.rootDirectory);
            return info;
        }// work

        public string CreateFolder(string path)
        {
            try
            {
                Directory.CreateDirectory(@"D:\Cursova\Clients\" + path);
                return "folder was created";
            }
            catch
            {
                return "error";
            }
        }

        public Client GetClient(string login)
        {
            Client client = null;


            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = @"Server = МІША-ПК\SQLSERVER_CUB; Database=CourseworDotNet; User Id=sa; Password=1";
                con.Open();

                SqlCommand com = new SqlCommand();
                SqlParameter loginPar = new SqlParameter("@login", System.Data.SqlDbType.VarChar);
                loginPar.Value = login;
                com.Parameters.Add(loginPar);
                //com.Parameters.Add(new SqlParameter("@login",System.Data.SqlDbType.VarChar).Value=login);

                com.CommandText = "select * from Clients where Ilogin=@login";
                com.Connection = con;
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();

                client = new Client((string)reader["name"], (string)reader["surname"], (string)reader["Ilogin"], (string)reader["Ipassword"],
                         (string)reader["rootDirectory"], (DateTime)reader["dateOfBirth"], (int)reader["idClient"]);
                

                reader.Dispose();
            }
            finally
            {
                con.Dispose();

            }

            return client;
        }// work

        public string DeleteFolder(string path)
        {
            try
            {
                Directory.Delete(Path.Combine(@"D:\Cursova\Clients\", path), true);
                return "Directory deleted";
            }
            catch
            {
                return "error";
            }
        } // work

        public bool SingIn(Client client, string password)
        {
            if (client.password.Equals(password))
                return true;
            return false;
        }// work

        public bool DeleteAccount(Client client)
        {
            try
            {
                SqlConnection con = new SqlConnection();


                con.ConnectionString = @"Server = МІША-ПК\SQLSERVER_CUB; Database=CourseworDotNet; User Id=sa; Password=1";
                con.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = con;


                SqlParameter login = new SqlParameter("@login", System.Data.SqlDbType.VarChar);

                login.Value = client.login;


                command.Parameters.Add(login);


                command.CommandText = "delete Clients where Ilogin = @login";

                command.ExecuteNonQuery();

                Directory.Delete(client.rootDirectory,true);
                return true;
            }
            catch
            {
                return false;
            }
        } // work


        public bool DeleteFile(string path)
        {
            try
            {
                File.Delete(Path.Combine(@"D:\Cursova\Clients\", path));
                return true;
            }
            catch
            {
                return false;
            }
        }// work
    }
}
