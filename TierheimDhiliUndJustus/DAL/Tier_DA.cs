namespace TierheimDhiliUndJustus.DAL
{
    using MySqlConnector;
    using System.Drawing;
    using TierheimDhiliUndJustus.BLL;
    using System.Data.SqlClient;
    using System.IO;
    /*using MySql.Data*/


    public static class Tier_DA
    {
        public static string sqlstatement = "";
        public static List<Tier> GetTier()
        {
            List<Tier> tierList = new List<Tier>();
            

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();

               
                sqlstatement = "SELECT * FROM tier";


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {                 
                        while (reader.Read())
                        {

                            Tier tier = new Tier(
                            (int)reader["ID_Tier"],
                            (string)reader["Tiername"],
                            (DateTime)reader["Geburtsdatum"],
                            (string)reader["Geschlecht"],
                            (string)reader["Beschreibung"],
                            (SByte)reader["Fundtier"],
                            (int)reader["FK_Tierrasse_Tier"]); ;

                            tierList.Add(tier);
                        }
                                  
                    }
                }

             
            }
            return tierList;
        }

        public static Tier GetOneTier(int tierid)
        {
            Tier neuesTier = new Tier();
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();
                sqlstatement = "SELECT * FROM tier WHERE ID_Tier = " + tierid;



                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            neuesTier.ID_Tier = (int)reader["ID_Tier"];
                            neuesTier.Tiername = (string)reader["Tiername"];
                            neuesTier.Geburtsdatum = (DateTime)reader["Geburtsdatum"];
                            neuesTier.Geschlecht = (string)reader["Geschlecht"];
                            neuesTier.Beschreibung = (string)reader["Beschreibung"];
                            neuesTier.Fundtier = (SByte)reader["Fundtier"];
                            neuesTier.FK_Tierrasse_Tier = (int)reader["FK_Tierrasse_Tier"];

                        }
                    }
                }
            }
            return neuesTier;

        }

        public static string GetImage(int tierid)
        {
            byte[] imageBytes = null;

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();
                sqlstatement = "SELECT Bild FROM tier WHERE ID_Tier = " + tierid;



                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        imageBytes = (byte[])reader["Bild"];

                    }
                }
            }

            return "data:image/png;base64," + Convert.ToBase64String(imageBytes, Base64FormattingOptions.None);
        }
    }  
}
