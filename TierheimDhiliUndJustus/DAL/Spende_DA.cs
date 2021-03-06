using System.Drawing;
using TierheimDhiliUndJustus.BLL;
using System.Data.SqlClient;
using System.IO;
using MySql.Data.MySqlClient;

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

        public static List<Spende> GetSpendenwithKunde(int kunde_id)
        {
            List<Spende> lst_kundenspenden = new List<Spende>();

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT * FROM spende WHERE FK_Kunde_Spende = @kundeid ORDER BY ID_Spende ASC";


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@kundeid", MySqlDbType.Int32) { Value = kunde_id });

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Spende spende = new Spende(
                            (int)reader["ID_Spende"],
                            (decimal)reader["Betrag"],
                            (int)reader["FK_Kunde_Spende"],
                            (int)reader["FK_Zahlungsart_Spende"]);

                            lst_kundenspenden.Add(spende);
                        }

                    }
                }
            }
            return lst_kundenspenden;
        }

        
    }

}
