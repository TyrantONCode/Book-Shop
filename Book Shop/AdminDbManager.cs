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
    internal class AdminDbManager
    {
        public static string root;
        public static string connectionKey;
        public static List<int> VipUsers = new List<int>();
        public static List<int> VipBooks = new List<int>();
        

        public static void AddBook(string title, string writer,
            int publishYear, string brief, float cost, string imagepath, string pdfpath)
        {
            BookDbManager.AddData(title, writer, publishYear, brief, cost, imagepath, pdfpath);
        }

        public static void AddVipUser(int userid)
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "update [Table] set vip = '"+true+"' where id like '"+userid+"'";
            SqlCommand cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();            
            VipUsers.Add(userid);
        }


        public static void AddVipBook(int bookid)
        {
            root = Path.GetFullPath("App_Data\\BookDb.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "update [Table] set vip = '" + true + "' where id like '" + bookid + "'";
            SqlCommand cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            VipBooks.Add(bookid);
        }


        public static void DeletBook(int bookid)
        {
            root = Path.GetFullPath("App_Data\\BookDb.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "delete from [Table] where id like '"+bookid+"'";
            SqlCommand cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }


        public static bool EditBook(int id, string title = "", string writer = "",
            string publishYear = "", string breif = "", double cost = 0,string imagepath = "",
            string pdfpath = "")
        {
            root = Path.GetFullPath("App_Data\\UserDataBase.mdf").ToString().Replace(@"Book Shop\bin\Debug\net6.0-windows\", "");
            connectionKey = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={root};Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(connectionKey);
            conn.Open();
            string command = "select * from [Table] where id like '" + id + "'";
            SqlCommand cmd = new SqlCommand(command, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            string oldTitle = reader.GetString(1);
            string oldWriter = reader.GetString(2);
            string oldYear = reader.GetString(3);
            string oldBreif = reader.GetString(4);
            double oldCost = reader.GetDouble(5);
            string oldImagepath = reader.GetString(6);
            string oldPDFpath = reader.GetString(7);
            conn.Close();
            SqlConnection conn2 = new SqlConnection(connectionKey);
            conn2.Open();
            command = "update [Table] set title = '" + title == "" ? oldTitle : title + "', " +
                "wirter = '" + writer == "" ? oldWriter : writer + "'," +
                "publishyear = '" + publishYear == ""  ? oldYear : publishYear + "'," +
                "breif = '" + breif == "" ? oldBreif : breif + "', " +
                "cover = '" + imagepath == "" ? oldImagepath : imagepath + "'," +
                "pdfpath = '"+pdfpath == "" ? oldPDFpath : pdfpath +"'" +
                " where id like '" + id + "'";
            cmd = new SqlCommand(command, conn2);
            cmd.ExecuteNonQuery();
            conn2.Close();
            if (title == "" && writer == "" && publishYear == "" && breif == "" 
                && cost == 0 && imagepath == "" && pdfpath == "")
            {
                return false;
            }
            return true;
        }




    }
}
