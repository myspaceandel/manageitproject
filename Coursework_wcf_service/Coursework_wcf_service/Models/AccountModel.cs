using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Coursework_wcf_service.Models
{
    public class AccountModel
    {
        private List<Account> listAccounts = new List<Account>();
        public AccountModel()
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = @"Server = МІША-ПК\SQLSERVER_CUB; Database=CourseworDotNet; User Id=sa; Password=1";
                    con.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = con;
                    command.CommandText = "select Ilogin,Ipassword from Clients";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listAccounts.Add(new Account() { UserName = (string)reader["Ilogin"], Password = (string)reader["Ipassword"] });
                    }
                   // listAccounts.Add(new Account() { UserName = (string)reader["Ilogin"], Password = (string)reader["Ipassword"] });
                }
            }
            catch
            {

            }
        }
        public bool login(string username, string password)
        {
            return listAccounts.Count(acc => acc.Password.Equals(password) && acc.UserName.Equals(username)) > 0;
        }

    }
}