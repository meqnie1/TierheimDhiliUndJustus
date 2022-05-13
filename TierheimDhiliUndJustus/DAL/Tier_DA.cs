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

        public static List<Tier> GetTierWithFilterTierart(List<int> checkboxes)
        {
            string whereStatement = "";
            List<Tier> tierList = new List<Tier>();
            if (checkboxes.Count != 0)
            {
                whereStatement = "WHERE tierrasse.FK_Tierart_Tierrasse IN(";
                foreach (int item in checkboxes)
                {
                    whereStatement += item;
                    if (item != checkboxes.Last())
                    {
                        whereStatement += ", ";
                    }
                }
                whereStatement += ")";
            }

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();
                sqlstatement = "SELECT * FROM tier JOIN tierrasse ON tier.FK_Tierrasse_Tier = tierrasse.ID_Tierrasse " + whereStatement;



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

            whereStatement = "";
            return tierList;

        }

        public static List<Tier> GetTierWithFilterTierrasse(List<int> checkboxes)
        {
            string whereStatement = "";
            List<Tier> tierList = new List<Tier>();
            if (checkboxes.Count != 0)
            {
                whereStatement = "WHERE tier.FK_Tierrasse_Tier IN(";
                foreach (int item in checkboxes)
                {
                    whereStatement += item;
                    if (item != checkboxes.Last())
                    {
                        whereStatement += ", ";
                    }
                }
                whereStatement += ")";
            }

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();
                sqlstatement = "SELECT * FROM tier " + whereStatement;



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

            whereStatement = "";
            return tierList;

        }
    }  
}
