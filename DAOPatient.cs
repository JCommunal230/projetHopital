using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetHopital
{
    class DAOPatient
    {   
        private string connectionString = @"Data Source=LAPTOP-E7P98BHB\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";

        public List<Patient> Select()
        {
            string sql = "select * from patients";
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);
            List<Patient> liste = new List<Patient>();

            connexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Patient p = new Patient();
                p.Id = reader.GetInt32(0);
                p.Nom = reader.GetString(1);
                p.Prenom = reader.GetString(2);
                p.Age = reader.GetInt32(3);
                p.Adresse = reader.IsDBNull(4) ? "" : reader.GetString(4);
                p.Telephone= reader.IsDBNull(5) ? "" : reader.GetString(5);
                liste.Add(p);
            }                
            connexion.Close();
            return liste;
        }
        public Patient SelectById(int id)
        {
            string sql = "select * from patients where id=" + id;
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);
            Patient p = null;

            connexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                p = new Patient();
                p.Id = reader.GetInt32(0);
                p.Nom = reader.GetString(1);
                p.Prenom = reader.GetString(2);
                p.Age = reader.GetInt32(3);
                p.Adresse = reader.IsDBNull(4) ? "" : reader.GetString(4);
                p.Telephone = reader.IsDBNull(5) ? "" : reader.GetString(5);
            }                
            connexion.Close();
            return p;
        }
        public void Insert(Patient p)
        {
            string sql = "insert into patients values(@a,@b,@c,@d,@e,@f)";
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = connexion.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add("a", SqlDbType.Int).Value = p.Id;
            command.Parameters.Add("b", SqlDbType.NVarChar).Value = p.Nom;
            command.Parameters.Add("c", SqlDbType.NVarChar).Value = p.Prenom;
            command.Parameters.Add("d", SqlDbType.Int).Value = p.Age;
            command.Parameters.Add("e", SqlDbType.NVarChar).Value = p.Adresse;
            command.Parameters.Add("f", SqlDbType.NVarChar).Value = p.Telephone;
            connexion.Open();
            command.ExecuteNonQuery();
            connexion.Close();
        }
        //Update met à jour téléphone et adresse seulement
        public void Update(Patient p)
        {
            string sql = "update patients set adresse=@y,telephone=@z where id=@x";
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = connexion.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add("x", SqlDbType.Int).Value = p.Id;
            command.Parameters.Add("y", SqlDbType.NVarChar).Value = p.Adresse;
            command.Parameters.Add("z", SqlDbType.NVarChar).Value = p.Telephone;
            connexion.Open();
            command.ExecuteNonQuery();
            connexion.Close();
        }
        //pas nécessaire
        public void Delete(int id)
        {
            string sql = "delete from patients where id=" + id;
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);
            connexion.Open();
            command.ExecuteNonQuery();
            connexion.Close();
        }
    }
}

