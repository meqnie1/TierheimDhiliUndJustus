using System.Drawing;
using TierheimDhiliUndJustus.BLL;
using System.Data.SqlClient;
using System.IO;
using MySql.Data.MySqlClient;

namespace TierheimDhiliUndJustus.DAL
{
    public static class Termin_DA
    {
        public static string sqlstatement = "";

        public static List<Termin> GetTermineWithTerminart(int terminart_id)
        {
            List<Termin> lst_termine = new List<Termin>();
            DateTime datum;

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT ID_Termin, Datum, Uhrzeit, Gebucht, FK_Terminart_Termin FROM termin WHERE Gebucht = 0 AND FK_Terminart_Termin = @terminartid";


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@terminartid", MySqlDbType.Int32) { Value = terminart_id });

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

                            lst_termine.Add(termin);
                        }

                    }
                }


            }
            return lst_termine;
        }

        public static Termin GetTermin(int termin_id)
        {
            Termin termin = new Termin();
            DateTime datum;


            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT ID_Termin, Datum, Uhrzeit, Gebucht, FK_Terminart_Termin FROM termin WHERE ID_Termin = @terminid";


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@terminid", MySqlDbType.Int32) { Value = termin_id });

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

        public static void BookATermin(int terminid, int tierid)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "UPDATE termin SET FK_Tier_Termin = @tierid, Gebucht = 1, FK_Kunde_Termin = @kundenid WHERE ID_Termin = @terminid";


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    MySqlParameter paramIDTier = new MySqlParameter("@tierid", MySqlDbType.Int32);
                    paramIDTier.Value = tierid;
                    cmd.Parameters.Add(paramIDTier);

                    MySqlParameter paramIDTermin= new MySqlParameter("@terminid", MySqlDbType.Int32);
                    paramIDTermin.Value = terminid;
                    cmd.Parameters.Add(paramIDTermin);

                    MySqlParameter paramIDKunde = new MySqlParameter("@kundenid", MySqlDbType.Int32);
                    paramIDKunde.Value = LoginConfig.Angemeldet;
                    cmd.Parameters.Add(paramIDKunde);

                    cmd.ExecuteNonQuery();
                }


            }
        }
        
        public static List<Termin> GetTermineWithKunde(int kunde_id)
        {
            DateTime datum;
            List<Termin> lst_kundentermine = new List<Termin>();

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();

                sqlstatement = "SELECT ID_Termin, Datum, Uhrzeit, Gebucht, FK_Terminart_Termin FROM termin WHERE FK_Kunde_Termin = @kundeid ORDER BY Datum";

                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@kundeid", MySqlDbType.Int32) { Value = kunde_id });

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

                            lst_kundentermine.Add(termin);
                        }

                    }
                }
            }
            return lst_kundentermine;
        }

        public static string GetTiernamefromTermin(int termin_id)
        {
            string name = "";

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();

                sqlstatement = "SELECT Tiername FROM tier JOIN termin ON termin.FK_Tier_Termin = tier.ID_Tier WHERE termin.ID_Termin = @terminid";

                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@terminid", MySqlDbType.Int32) { Value = termin_id });

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            name = (string)reader["Tiername"];
                        }
                    }
                }
            }
            return name;
        }

        public static void RemoveKundefromSpecificTermin(int termin_id)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();

                string sqlstatement = "UPDATE termin SET FK_Kunde_Termin = null, FK_Tier_Termin = null,Gebucht = 0 WHERE ID_Termin = @terminid";

                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@terminid", MySqlDbType.Int32) { Value = termin_id });

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void RemoveKundefromTermin(int kunde_id)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();
                string sqlstatement = "UPDATE termin SET FK_Kunde_Termin = null, FK_Tier_Termin = null,Gebucht = 0 WHERE FK_Kunde_Termin = @kundeid";

                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@kundeid", MySqlDbType.Int32) { Value = kunde_id });

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public static string GetTerminartWithTerminID(int termin_id)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();
                string terminart = "";

                string sqlstatement = "SELECT terminart.bezeichnung FROM termin JOIN terminart ON termin.FK_Terminart_Termin = terminart.ID_terminart WHERE ID_Termin = @terminid";

                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@terminid", MySqlDbType.Int32) { Value = termin_id });

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            terminart = (string)reader["bezeichnung"];
                        }

                    }
                }

            return terminart;

            }
        }

        public static long GetTermineWithKundeForCertainTier(int tier_id)
        {
            long count = 0;

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT COUNT(ID_Termin) AS 'count' FROM termin WHERE FK_Kunde_Termin = " + LoginConfig.Angemeldet + " AND FK_Tier_Termin = @tierid";


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@tierid", MySqlDbType.Int32) { Value = tier_id });

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = (long)reader["count"];
                        }

                    }
                }
            }
            return count;
        }

        public static void RemoveTierfromTermin(int tier_id)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();
                string sqlstatement = "UPDATE termin SET FK_Kunde_Termin = null, FK_Tier_Termin = null,Gebucht = 0 WHERE FK_Tier_Termin = @tierid";

                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@tierid", MySqlDbType.Int32) { Value = tier_id });

                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
    
}
