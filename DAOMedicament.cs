using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetHopital
{
    class DAOMedicament
    {
        private string connectionString = @"Data Source=LAPTOP-E7P98BHB\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";

        public List<Medicament> Select()
        {
            string sql = "select * from medicaments";
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);
            List<Medicament> liste = new List<Medicament>();

            connexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                liste.Add(new Medicament(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
            connexion.Close();
            return liste;
        }
        public Medicament SelectById(int id)
        {
            string sql = "select * from medicaments where idMedicaments=" + id;
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);
            Medicament med = null;

            connexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                med = new Medicament(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
            connexion.Close();
            return med;
        }
        public void Insert(Medicament med)
        {
            string sql = "insert into medicaments values(@a,@b,@c,@d)";
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = connexion.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add("a", SqlDbType.Int).Value = med.IdMedicaments;
            command.Parameters.Add("b", SqlDbType.NVarChar).Value = med.Nom;
            command.Parameters.Add("c", SqlDbType.NVarChar).Value = med.Prix;
            command.Parameters.Add("d", SqlDbType.Int).Value = med.Quantite;

            connexion.Open();
            command.ExecuteNonQuery();
            connexion.Close();
        }
        public void Delete(int id)
        {
            string sql = "delete from medicaments where idMedicaments=" + id;
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);

            connexion.Open();
            command.ExecuteNonQuery();
            connexion.Close();
        }
        public void UpdateStock(Medicament med) //Variation des stocks quand ordonnance faite
        {
            string sql = "update medicaments set quantite=@y where idMedicaments=@x";
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = connexion.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add("x", SqlDbType.Int).Value = med.IdMedicaments;
            command.Parameters.Add("y", SqlDbType.NVarChar).Value = med.Quantite;
            connexion.Open();
            command.ExecuteNonQuery();
            connexion.Close();
        }
        public void UpdateAll(Medicament med) 
        {
            string sql = "update medicaments set nom=@b,prix=@c,quantite=@d where idMedicaments=@a";

            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = connexion.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add("a", SqlDbType.Int).Value = med.IdMedicaments;
            command.Parameters.Add("b", SqlDbType.NVarChar).Value = med.Nom;
            command.Parameters.Add("c", SqlDbType.NVarChar).Value = med.Prix;
            command.Parameters.Add("d", SqlDbType.Int).Value = med.Quantite;

            connexion.Open();
            command.ExecuteNonQuery();
            connexion.Close();
        }
     }
}
