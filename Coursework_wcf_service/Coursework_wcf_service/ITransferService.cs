using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using Coursework_wcf_service.DB_Classes;
using Coursework_wcf_service.MessageContrants;

namespace Coursework_wcf_service
{
    [ServiceContract]
    public interface ITransferService
    {
        [OperationContract]
        string GetDiskSize(Client client);

        [OperationContract]
        RemoteFileInfo DownloadFile(DownloadRequest request);

        [OperationContract]
        void UploadFile(RemoteFileInfo request);

        [OperationContract]
        string CreateFolder(string path);

        [OperationContract]
        string DeleteFolder(string path);

        [OperationContract]
        Client GetClient(string path);

        [OperationContract]
        System.IO.DirectoryInfo GetRootRepository(Client client);

        [OperationContract]
        bool SingIn(Client client, string password);

        [OperationContract]
        bool DeleteAccount(Client client);

        [OperationContract]
        bool DeleteFile(string path);
    }
}