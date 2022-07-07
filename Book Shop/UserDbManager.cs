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

        public static string root;
        public static string connectionKey;
       
        public static void AddData(string firstname, string lastname,
            string password, string email, string phone, float money)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            string books = "";
            conn.Open();
            string command = "select max(id) + 1 from [Table]";
            SqlCommand cmd = new SqlCommand(command, conn);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            command = "insert into [Table] values ('" + id + "','" + firstname + "','" + lastname + "','" + password + "','" + email + "','" + phone + "','" + money + "','" + books + "')";
            cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static bool UserLogin(string email, string password)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where email like '"+email+"' and password like '"+password+"'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            bool output = reader.Read();
            conn.Close();
            return output;
        }

        public static bool ValidLoginEmail(string email)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where email like '"+email+"'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            bool output = reader.Read();
            conn.Close();
            return output;
        }


        public static string AddFavBooks(string favbookstring, int book_id)
        {
            if (favbookstring.Length == 0)
            {
                favbookstring += book_id;
            }
            else
            {
                favbookstring += $" {book_id}";
            }
            return favbookstring;
        }


        public static int[] FavBookIdList(string email)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where email like '" + email + "'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            string[] favbooks = reader.GetString(7).Split();
            conn.Close();
            int[] output = new int[favbooks.Length];
            for (int i = 0; i < favbooks.Length; i++)
            {
                output[i] = int.Parse(favbooks[i]);
            }
            return output;
        }
    }

}
