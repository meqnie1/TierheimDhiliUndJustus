namespace TierheimDhiliUndJustus.DAL
{
    using MySqlConnector;
    using System.Drawing;
    using TierheimDhiliUndJustus.BLL;
    using System.Data.SqlClient;
    using System.IO;

    public static class Tierart_DA
    {
        public static string sqlstatement = "";
        public static List<Tierart> GetTierarten()
        {
            List<Tierart> tierartlist = new List<Tierart>();


            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT * FROM tierart";


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Tierart tierart = new Tierart(
                                (int)reader["ID_Tierart"],
                                (string)reader["Tierartname"]);

                            tierartlist.Add(tierart);
                        }

                    }
                }


            }
            return tierartlist;
        }
    }
}
