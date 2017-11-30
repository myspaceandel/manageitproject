using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Coursework_wcf_service.MessageContrants
{
    [MessageContract]
    public class RemoteFileInfo //: IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageHeader(MustUnderstand = true)]
        public long Length;

        [MessageBodyMember(Order = 1)]
        public System.IO.Stream FileByteStream;

        [MessageHeader(MustUnderstand = true)]
        public string uploadFolder;

        //public void Dispose()
        //{
        //    if (FileByteStream != null)
        //    {
        //        FileByteStream.Close();
        //        FileByteStream = null;
        //    }
        //}
    }
}