using Coursework_wcf_service.DB_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_wcf_service
{
    [ServiceContract]
    public interface IRegistryContract
    {
        [OperationContract]
        string Registry(Client client);
    }
   
}
