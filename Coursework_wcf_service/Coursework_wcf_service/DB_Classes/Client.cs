using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursework_wcf_service.DB_Classes
{
    [Serializable]
    public class Client
    {
        public int idClient;
        public string name;
        public string surname;
        public string login;
        public string password;
        public string rootDirectory;
        public DateTime birthDate;


        public Client(string name, string surname, string login, string password, string rootDirectory, DateTime date, int idClient)
        {
            this.idClient = idClient;
            this.name = name;
            this.surname = surname;
            this.login = login;
            this.password = password;
            this.rootDirectory = rootDirectory;
            this.birthDate = date.Date;
        }
    }
}