using MySqlConnector;
using System.Drawing;
using TierheimDhiliUndJustus.BLL;
using System.Data.SqlClient;
using System.IO;

namespace TierheimDhiliUndJustus.DAL
{
    public static class Zahlungsart_DA
    {
        public static string sqlstatement = "";

        public static List<Zahlungsart> GetZahlungsarten()
        {
            List<Zahlungsart> zahlungslist = new List<Zahlungsart>();
            DateTime datum;


            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT * FROM zahlungsart";


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Zahlungsart art = new Zahlungsart(
                            (int)reader["ID_Zahlungsart"],
                            (string)reader["Zahlungsartname"]);

                            zahlungslist.Add(art);
                        }

                    }
                }


            }
            return zahlungslist;
        }

        public static string GetoneZahlungsart(int idzahlungsart)
        {
            string zahlungsart = "";

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();              
                sqlstatement = "SELECT Zahlungsartname FROM zahlungsart WHERE ID_Zahlungsart = " + idzahlungsart;


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            zahlungsart = (string)reader["Zahlungsartname"];
                        }

                    }
                }


            }
            return zahlungsart;
        }
    }

}
