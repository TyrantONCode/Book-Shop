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
    internal class BookDbManager
    {
        public static string root;
        public static string connectionKey;
        public static string imageRoot;

        public static void AddData(string title, string writer,
            int publishYear, string brief, float cost, string imagepath,string pdfpath)
        {
            root = Path.GetFullPath("App_Data\\BookDb.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            string books = "";
            conn.Open();
            string command = "select max(id) + 1 from [Table]";
            SqlCommand cmd = new SqlCommand(command, conn);
            int id = 0;
            try
            {
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (InvalidCastException)
            {
                id = 0;
            }
            command = "insert into [Table] values ('" + id + "','" + title + "','" + writer +"','" + publishYear + "','" + brief + "','" + cost + "','"+imagepath+", '"+pdfpath+"')";
            cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static bool ShowData(int id, out string title, out string writer,
            out int publishyear,out string breif, out float cost, out string imagepath)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where id like '" + id + "'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            bool output = reader.Read();
            conn.Close();
            if (output)
            {
                title = reader.GetString(0);
                writer = reader.GetString(1);
                publishyear = reader.GetInt32(2);
                breif = reader.GetString(3);
                cost = reader.GetFloat(4);
                imagepath = reader.GetString(5);
            }
            else
            {
                title = "";
                writer = "";
                publishyear = 0;
                breif = "";
                cost = 0;
                imagepath = "";
            }
            return output;
        }

    }
}
