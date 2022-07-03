using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.IO;

namespace Book_Shop
{
    internal class UserDbManager
    {
        public string firstName;
        public string lastName;
        public string password;
        public string email;
        public string phone;
        public float money;
        public static string root;
        public static string connectionKey;
        // public List<Book> bag;
        // public List<Book> bought;
        // public List<Book> bookmarks;
        public static void AddData(string firstname, string lastname,string username,
            string password, string email, string phone, float money)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select max(id) + 1 from [Table]";
            SqlCommand cmd = new SqlCommand(command, conn);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            command = "insert into [Table] values ('" + id + "','" + firstname + "','" + lastname + "','" + username + "','" + password + "','" + email + "','" + phone + "','" + money + "')";
            cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static bool UserLogin(string username, string password)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where username like '"+username+"' and password like '"+password+"'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            bool output = reader.Read();
            conn.Close();
            return output;
        }

        public static bool ValidUsername(string username)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where lower(username) like '"+username.ToLower()+"'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            bool output = reader.Read();
            conn.Close();
            return !output;
        }



    }

}
