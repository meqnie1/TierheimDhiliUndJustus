using MySqlConnector;
using System.Drawing;
using TierheimDhiliUndJustus.BLL;
using System.Data.SqlClient;
using System.IO;

namespace TierheimDhiliUndJustus.DAL
{
    public static class Spende_DA
    {
        public static string sqlstatement = "";

        public static void BookASpende(double betrag, int zahlungsartid)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "INSERT INTO spende(Betrag, FK_Kunde_Spende, FK_Zahlungsart_Spende) VALUES (@betrag,@kundeid,@zahlungsartid)";


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    MySqlParameter paramBetrag = new MySqlParameter("@betrag", MySqlDbType.Double);
                    paramBetrag.Value = Math.Round(betrag,2);
                    cmd.Parameters.Add(paramBetrag);

                    MySqlParameter paramIDKunde = new MySqlParameter("@kundeid", MySqlDbType.Int32);
                    paramIDKunde.Value = LoginConfig.Angemeldet;
                    cmd.Parameters.Add(paramIDKunde);

                    MySqlParameter paramIDZahlung = new MySqlParameter("@zahlungsartid", MySqlDbType.Int32);
                    paramIDZahlung.Value = zahlungsartid;
                    cmd.Parameters.Add(paramIDZahlung);

                    cmd.ExecuteNonQuery();
                }


            }
        }
    }

}
