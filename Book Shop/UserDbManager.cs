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
            string bought_books = "";
            conn.Open();
            string command = "select max(id) + 1 from [Table]";
            SqlCommand cmd = new SqlCommand(command, conn);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            command = "insert into [Table] values ('" + id + "','" + firstname + "','" + lastname + "','" + password + "','" + email + "','" + phone + "','" + money + "','" + books + "', '"+bought_books+"')";
            cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static bool UserLogin(string email, string password, out int id)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where email like '"+email+"' and password like '"+password+"'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            bool output = reader.Read();
            
            if (output)
            {
                id = reader.GetInt32(0);
                return true;
            }
            conn.Close();
            id = -1;
            return false;
            
        }

        public static bool ValidSignupEmail(string email)
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
            return !output;
        }


        public static void AddFavBooks(int id, int book_id)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where id like '" + id + "'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            string favbookstring = reader.GetString(7);
            conn.Close();
            if (favbookstring.Length == 0)
            {
                favbookstring += book_id;
            }
            else
            {
                favbookstring += $" {book_id}";
            }
            SqlConnection conn2 = new SqlConnection(connectionKey);
            command = "update [Table] set favebooks = '" + favbookstring + "' where id like '"+id+"'";
            cmd = new SqlCommand(command, conn2);
            cmd.ExecuteNonQuery();
            conn2.Close();
        }


        public static int[] FavBookIdList(int id)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where id like '" + id + "'";
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


        public static void RemoveFavBook(int id, int book_id)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where id like '" + id + "'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            string favbookstring = reader.GetString(7);
            conn.Close();
            string[] books = favbookstring.Split();
            List<string> newbooks = new List<string>();
            foreach (string book in books)
            {
                if (book != book_id.ToString())
                {
                    newbooks.Add(book);
                }
            }
            favbookstring = "";
            for (int i = 0; i < newbooks.Count; i++)
            {
                if (i == 0)
                {
                    favbookstring += newbooks[0];
                }
                else
                {
                    favbookstring += $" {newbooks[i]}";
                }
            }
            SqlConnection conn2 = new SqlConnection(connectionKey);
            command = "update [Table] set favebooks = '" + favbookstring + "' where id like '" + id + "'";
            cmd = new SqlCommand(command, conn2);
            cmd.ExecuteNonQuery();
            conn2.Close();
        }

        public static void AddBoughtBooks(int id, int book_id)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where id like '" + id + "'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            string boughtbooks = reader.GetString(8);
            conn.Close();
            if (boughtbooks.Length == 0)
            {
                boughtbooks += book_id;
            }
            else
            {
                boughtbooks += $" {book_id}";
            }
            SqlConnection conn2 = new SqlConnection(connectionKey);
            command = "update [Table] set boughtbooks = '" + boughtbooks + "' where id like '" + id + "'";
            cmd = new SqlCommand(command, conn2);
            cmd.ExecuteNonQuery();
            conn2.Close();
        }


        public static int[] BoughtBookIdList(int id)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where id like '" + id + "'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            string[] boughtbooks = reader.GetString(8).Split();
            conn.Close();
            int[] output = new int[boughtbooks.Length];
            for (int i = 0; i < boughtbooks.Length; i++)
            {
                output[i] = int.Parse(boughtbooks[i]);
            }
            return output;
        }


        public static void RemoveBoughtBook(int id, int book_id)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where id like '" + id + "'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            string boughtbooks = reader.GetString(8);
            conn.Close();
            string[] books = boughtbooks.Split();
            List<string> newbooks = new List<string>();
            foreach (string book in books)
            {
                if (book != book_id.ToString())
                {
                    newbooks.Add(book);
                }
            }
            boughtbooks = "";
            for (int i = 0; i < newbooks.Count; i++)
            {
                if (i == 0)
                {
                    boughtbooks += newbooks[0];
                }
                else
                {
                    boughtbooks += $" {newbooks[i]}";
                }
            }
            SqlConnection conn2 = new SqlConnection(connectionKey);
            command = "update [Table] set boughtbooks = '" + boughtbooks + "' where id like '" + id + "'";
            cmd = new SqlCommand(command, conn2);
            cmd.ExecuteNonQuery();
            conn2.Close();
        }


        public static bool ChargeWallet(int id, double amount)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where id like '" + id + "'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            bool output = reader.Read();
            double money = amount;
            if (output && money + reader.GetDouble(6) > 0)
            {
                money += reader.GetDouble(6);
                SqlConnection conn2 = new SqlConnection(connectionKey);
                conn2.Open();
                command = "update [Table] set money = '" + money + "' where id like '" + id + "'";
                cmd = new SqlCommand(command, conn2);
                cmd.ExecuteNonQuery();
                conn2.Close();
                return true;
            }
            conn.Close();
            return false;
            
            
        }


        public static bool EditProfile(int id, string name = "", string lastname = "",
            string email = "", string phone = "", string password = "")
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where id like '" + id + "'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            string oldName = reader.GetString(1);
            string oldLastName = reader.GetString(2);
            string oldPassword = reader.GetString(3);
            string oldEmail = reader.GetString(4);
            string oldPhone = reader.GetString(5);
            conn.Close();
            SqlConnection conn2 = new SqlConnection(connectionKey);
            conn2.Open();
            command = "update [Table] set firstname = '" + name == "" ? oldName : name + "', " +
                "lastname = '" + lastname == "" ? oldLastName : lastname + "'," +
                "password = '"+password == "" ? oldPassword : password +"'," +
                "email = '" + email == "" ? oldEmail : email + "', " +
                "phone = '" + phone == "" ? oldPhone : phone + "' where id like '"+id+"'";
            cmd = new SqlCommand(command, conn2);
            cmd.ExecuteNonQuery();
            conn2.Close();
            if (name == "" && lastname == "" && phone == "" && email == "")
            {
                return false;
            }
            return true;
        }


    }

}
