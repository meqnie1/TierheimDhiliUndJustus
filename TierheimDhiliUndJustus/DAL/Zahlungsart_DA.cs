using System.Drawing;
using TierheimDhiliUndJustus.BLL;
using System.Data.SqlClient;
using System.IO;
using MySql.Data.MySqlClient;

namespace TierheimDhiliUndJustus.DAL
{
    public static class Zahlungsart_DA
    {
        public static string sqlstatement = "";

        public static List<Zahlungsart> GetAllZahlungsarten()
        {
            List<Zahlungsart> lst_zahlungsarten = new List<Zahlungsart>();
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

                            lst_zahlungsarten.Add(art);
                        }

                    }
                }


            }
            return lst_zahlungsarten;
        }

        public static string GetOneZahlungsart(int zahlungsart_id)
        {
            string zahlungsart = "";

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();              
                sqlstatement = "SELECT Zahlungsartname FROM zahlungsart WHERE ID_Zahlungsart = @zahlungsartid";


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@zahlungsartid", MySqlDbType.Int32) { Value = zahlungsart_id });

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
