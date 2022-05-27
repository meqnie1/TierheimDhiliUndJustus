using MySqlConnector;
using System.Drawing;
using TierheimDhiliUndJustus.BLL;
using System.Data.SqlClient;
using System.IO;

namespace TierheimDhiliUndJustus.DAL
{
    public static class Termin_DA
    {
        public static string sqlstatement = "";

        public static List<Termin> GetTermineWithTerminart(int terminartid)
        {
            List<Termin> terminlist = new List<Termin>();
            DateTime datum;


            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT ID_Termin, Datum, Uhrzeit, Gebucht, FK_Terminart_Termin FROM termin WHERE Gebucht = 0 AND FK_Terminart_Termin = " + terminartid;


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            datum = ((DateTime)reader["Datum"]).Date;
                            datum = datum.Add(((TimeSpan)reader["Uhrzeit"]));

                            Termin termin = new Termin(
                            (int)reader["ID_Termin"],
                            (DateTime)datum,
                            (SByte)reader["Gebucht"],
                            (int)reader["FK_Terminart_Termin"]);

                            terminlist.Add(termin);
                        }

                    }
                }


            }
            return terminlist;
        }

        public static Termin GetTermin(int idtermin)
        {
            Termin termin = new Termin();
            DateTime datum;


            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT ID_Termin, Datum, Uhrzeit, Gebucht, FK_Terminart_Termin FROM termin WHERE ID_Termin = " + idtermin;


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            datum = ((DateTime)reader["Datum"]).Date;
                            datum = datum.Add(((TimeSpan)reader["Uhrzeit"]));

                            termin.ID_Termin = (int)reader["ID_Termin"];
                            termin.TerminDatum = (DateTime)datum;
                            termin.Gebucht = (SByte)reader["Gebucht"];
                            termin.FK_Terminart_Art = (int)reader["FK_Terminart_Termin"];
                        }
                    }
                }
            }
            return termin;
        }

        public static Termin BookATermin(int terminid, int tierid)
        {
            Termin termin = new Termin();


            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "UPDATE termin SET FK_Tier_Termin = @tierid, Gebucht = 1 WHERE ID_Termin = @terminid";


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    MySqlParameter paramIDTier = new MySqlParameter("@tierid", MySqlDbType.Int32);
                    paramIDTier.Value = tierid;
                    cmd.Parameters.Add(paramIDTier);

                    MySqlParameter paramIDTermin= new MySqlParameter("@terminid", MySqlDbType.Int32);
                    paramIDTermin.Value = terminid;
                    cmd.Parameters.Add(paramIDTermin);

                    cmd.ExecuteNonQuery();
                }


            }
            return termin;
        }
        
        public static List<Termin> GetTermineWithKunde(int kundenid)
        {
            
            DateTime datum;
            List<Termin> lstkundentermine = new List<Termin>();


            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT ID_Termin, Datum, Uhrzeit, Gebucht, FK_Terminart_Termin FROM termin WHERE FK_Kunde_Termin = " + kundenid + " ORDER BY Datum";


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            datum = ((DateTime)reader["Datum"]).Date;
                            datum = datum.Add(((TimeSpan)reader["Uhrzeit"]));

                            Termin termin = new Termin(
                            (int)reader["ID_Termin"],
                            (DateTime)datum,
                            (SByte)reader["Gebucht"],
                            (int)reader["FK_Terminart_Termin"]);

                            lstkundentermine.Add(termin);
                        }

                    }
                }
            }
            return lstkundentermine;
        }

        public static string GetTierfromTermin(int terminid)
        {
            DateTime datum;
            string tiername = "";
           


            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT tier.Tiername FROM termin JOIN tier ON termin.FK_Tier_Termin = tier.ID_Tier WHERE termin.ID_Termin = " + terminid;


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tiername = (string)reader["Tiername"];
                        }

                    }
                }
            }
            return tiername;
        }
    }
    
}
