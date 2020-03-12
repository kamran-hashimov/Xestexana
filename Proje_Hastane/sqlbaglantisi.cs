using System;

using System.Data.SqlClient;

namespace Proje_Hastane
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FKU6315\\Sql;Initial Catalog=HastaneProje;Integrated Security=True");
            connection.Open();
            return connection;
        }
    }
}
