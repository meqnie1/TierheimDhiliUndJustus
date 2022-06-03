namespace TierheimDhiliUndJustus.DAL
{
    using MySqlConnector;
    using System.Drawing;
    using TierheimDhiliUndJustus.BLL;
    using System.Data.SqlClient;
    using System.IO;

    public class Tierrasse_DA

        //TIERRASSEN METHODE UMBENENNEN AUF TIERRASSENWITHTIERARTID
    {
        public static string sqlstatement = "";

        public static List<Tierrasse> GetTierrasseWithTierartID(int tierart_ID)
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

        public static int GetTierartWithTierID(int tierid)
        {
            int tierart = 1;


            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT tierrasse.FK_Tierart_Tierrasse FROM tierrasse JOIN tier ON tierrasse.ID_Tierrasse = tier.FK_Tierrasse_Tier WHERE tier.ID_Tier = " + tierid;


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tierart = (int)reader["FK_Tierart_Tierrasse"];
                        }

                    }
                }


            }
            return tierart;
        }

        public static int GetTierartWithTierrasseID(int tierrasseid)
        {
            int tierart = 0;


            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT FK_Tierart_Tierrasse FROM tierrasse WHERE ID_Tierrasse = " + tierrasseid;


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tierart = (int)reader[0];
                        }

                    }
                }


            }
            return tierart;
        }
    }
}
