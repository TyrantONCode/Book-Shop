using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

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
        // public List<Book> bag;
        // public List<Book> bought;
        // public List<Book> bookmarks;
        public void AddData(int id,string firstname, string lastname,
            string password, string email, string phone, float money)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quotC: \Users\Armageddon\Desktop\Ap proj\Book - Shop\Book Shop\UserDb.mdf&quot; Integrated Security=True;Connect Timeout=30");
            conn.Open();
            string command = "insert into [Table] values ('"+id+"','"+firstname+"','"+lastname+"','"+password+"','"+email+"','"+phone+"','"+money+"')";
            SqlCommand cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        

    }
}
