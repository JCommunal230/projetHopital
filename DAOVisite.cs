using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetHopital
{
    class DAOVisite
    {
        private string connectionString = @"Data Source=LAPTOP-E7P98BHB\SQLEXPRESS;Initial Catalog=hopital-hn;Integrated Security=True";

        public List<Visite> Select()
        {
            string sql = "select * from visites";
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);
            List<Visite> liste = new List<Visite>();
            connexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Visite v = new Visite();
                v.Num_visite = reader.GetInt32(0);
                v.Id_patient = reader.GetInt32(1);
                v.Date_entree = reader.GetDateTime(2).ToString();
                v.Nom_medecin = reader.GetString(3);
                v.Num_salle = reader.GetInt32(4);
                v.Tarif = reader.GetInt32(5);
                v.Ordonnance = reader.IsDBNull(6) ? "" : reader.GetString(6);
                liste.Add(v);
            }            
            connexion.Close();
            return liste;
        }
        public List<Visite> SelectById(int id_patient)
        {
            string sql = "select * from visites where id_patient=" + id_patient;
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);
            List<Visite> liste = new List<Visite>();

            connexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Visite v = new Visite();
                v.Num_visite = reader.GetInt32(0);
                v.Id_patient = reader.GetInt32(1);
                v.Date_entree = reader.GetDateTime(2).ToString();
                v.Nom_medecin = reader.GetString(3);
                v.Num_salle = reader.GetInt32(4);
                v.Tarif = reader.GetInt32(5);
                v.Ordonnance = reader.IsDBNull(6) ? "" : reader.GetString(6);
                liste.Add(v);
            }
            connexion.Close();
            return liste;
        }
        public List<Visite> SelectByMedecin(string nom_medecin)
        {
            string sql = "select * from visites where nom_medecin='" + nom_medecin+"'";
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);
            List<Visite> liste = new List<Visite>();

            connexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Visite v = new Visite();
                v.Num_visite = reader.GetInt32(0);
                v.Id_patient = reader.GetInt32(1);
                v.Date_entree = reader.GetDateTime(2).ToString();
                v.Nom_medecin = reader.GetString(3);
                v.Num_salle = reader.GetInt32(4);
                v.Tarif = reader.GetInt32(5);
                v.Ordonnance = reader.IsDBNull(6) ? "" : reader.GetString(6);
                liste.Add(v);
            }
            connexion.Close();
            return liste;
        }
        public void Insert(Visite v)
        {
            string sql = "insert into visites values(@a,@b,@c,@d,@e,@f)";
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = connexion.CreateCommand();
            command.CommandText = sql;
            command.Parameters.Add("a", SqlDbType.Int).Value = v.Id_patient;
            command.Parameters.Add("b", SqlDbType.NVarChar).Value = v.Date_entree;
            command.Parameters.Add("c", SqlDbType.NVarChar).Value = v.Nom_medecin;
            command.Parameters.Add("d", SqlDbType.Int).Value = v.Num_salle;
            command.Parameters.Add("e", SqlDbType.Int).Value = v.Tarif;
            command.Parameters.Add("f", SqlDbType.NVarChar).Value = v.Ordonnance;

            connexion.Open();
            command.ExecuteNonQuery();
            connexion.Close();
        }
        //Pas nécessaire
        public void Delete(int num_visite)
        {
            string sql = "delete from visites where num_visite=" + num_visite;
            SqlConnection connexion = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connexion);
            connexion.Open();
            command.ExecuteNonQuery();
            connexion.Close();
        }   
    }
}
