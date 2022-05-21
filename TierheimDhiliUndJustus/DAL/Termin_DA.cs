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
    }
}
