using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetHopital
{
    class DAOAuthentification
    {
        private string connectionString = @"Data Source=LAPTOP-E7P98BHB\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";

        public Authentification SelectByLogin(string login)
        {
            string sql = "select * from authentification where login='" + login+"'";
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);
            Authentification a = null;

            connexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                a = new Authentification(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            connexion.Close();
            return a;
        }
    }
}
