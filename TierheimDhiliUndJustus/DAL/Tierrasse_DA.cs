namespace TierheimDhiliUndJustus.DAL
{
    using MySqlConnector;
    using System.Drawing;
    using TierheimDhiliUndJustus.BLL;
    using System.Data.SqlClient;
    using System.IO;

    public class Tierrasse_DA
    {
        public static string sqlstatement = "";
        public static List<Tierrasse> GetTierrassen(int tierart_ID)
        {
            List<Tierrasse> tierrasselist = new List<Tierrasse>();


            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT * FROM tierrasse WHERE FK_Tierart_Tierrasse = " + tierart_ID;


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Tierrasse tierrasse = new Tierrasse(
                                (int)reader["ID_Tierrasse"],
                                (string)reader["Tierrassenamen"],
                                (int)reader["FK_Tierart_Tierrasse"]);

                            tierrasselist.Add(tierrasse);
                        }

                    }
                }


            }
            return tierrasselist;
        }
    }
}
