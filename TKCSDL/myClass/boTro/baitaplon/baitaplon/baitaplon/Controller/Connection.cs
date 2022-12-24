using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace baitaplon
{
    class Connection
    {
        private static string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Dell Inspiron 5515\Desktop\ki5\Kì 1\Ki-I-Nam-3\C#\myClass\BTL\baitaplon\baitaplon\baitaplon\Model\Database1.mdf"";Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connect);
        }
    }
}
