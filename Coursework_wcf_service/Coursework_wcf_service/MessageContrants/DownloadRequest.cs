using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Coursework_wcf_service.MessageContrants
{

    [MessageContract]
    public class DownloadRequest
    {
        [MessageBodyMember]
        public string FileName;
    }

}