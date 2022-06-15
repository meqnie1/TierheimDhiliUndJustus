namespace TierheimDhiliUndJustus.DAL
{
    using System.Drawing;
    using TierheimDhiliUndJustus.BLL;
    using System.Data.SqlClient;
    using System.IO;
    using MySql.Data.MySqlClient;

    public static class Tier_DA
    {
        public static string sqlstatement = "";
        public static List<Tier> GetTier()
        {
            List<Tier> tierList = new List<Tier>();
            

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();

               
                sqlstatement = "SELECT * FROM tier WHERE Fundtier = 0";


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

        public static List<Tier> GetTierWithFilterTierrasse(List<int> checkboxes_tr, List<int> checkboxes_ta)
        {
            string whereStatement_tr = "IN(0)";
            string whereStatement_ta = "IN(0)";

            if (checkboxes_tr.Count != 0)
            {
                whereStatement_tr = GetWhereStatement(checkboxes_tr);
            }
            if (checkboxes_ta.Count != 0)
            {
                whereStatement_ta = GetWhereStatement(checkboxes_ta);
            }

            List<Tier> tierList = new List<Tier>();

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();
                sqlstatement = "SELECT * FROM tier JOIN tierrasse ON tier.FK_Tierrasse_Tier = " +
                    "tierrasse.ID_Tierrasse WHERE fundtier = 0 and (tier.FK_Tierrasse_Tier " + whereStatement_tr + " OR tierrasse.FK_Tierart_Tierrasse " + whereStatement_ta + ")";



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

        public static string GetWhereStatement(List<int> checkboxes)
        {
            string wherestatement = "";
            if (checkboxes.Count != 0)
            {
                wherestatement = "IN(";
                foreach (int item in checkboxes)
                {
                    wherestatement += item;
                    if (item != checkboxes.Last())
                    {
                        wherestatement += ", ";
                    }
                }
                wherestatement += ")";
            }

            return wherestatement;
        }

        public static List<Tier> GetTierExceptTierID(int tierid)
        {
            List<Tier> tierList = new List<Tier>();


            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT * FROM tier WHERE ID_Tier != " + tierid;


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

        public static List<Tier> GetFundtiere()
        {
            List<Tier> tierList = new List<Tier>();


            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "SELECT * FROM tier WHERE Fundtier = 1";


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

        public static List<Tier> GetFundtierWithFilterTierrasse(List<int> checkboxes_tr, List<int> checkboxes_ta)
        {
            string whereStatement_tr = "IN(0)";
            string whereStatement_ta = "IN(0)";

            if (checkboxes_tr.Count != 0)
            {
                whereStatement_tr = GetWhereStatement(checkboxes_tr);
            }
            if (checkboxes_ta.Count != 0)
            {
                whereStatement_ta = GetWhereStatement(checkboxes_ta);
            }

            List<Tier> tierList = new List<Tier>();

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();
                sqlstatement = "SELECT * FROM tier JOIN tierrasse ON tier.FK_Tierrasse_Tier = " +
                    "tierrasse.ID_Tierrasse WHERE Fundtier = 1 AND (tier.FK_Tierrasse_Tier " + whereStatement_tr + " OR tierrasse.FK_Tierart_Tierrasse " + whereStatement_ta + ")";



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

        public static void CreateTier(Tier neuestier)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();

                string sqlstatement = "INSERT INTO tier(`Tiername`, `Geburtsdatum`, `Geschlecht`, `Beschreibung`, `Fundtier`, `FK_Tierrasse_Tier`) VALUES (@tiername, @geburtsdatum, @geschlecht, @beschreibung, @fundtier, @fk_tierrasse_tier)";

                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@tiername", MySqlDbType.VarChar, 20) { Value = neuestier.Tiername });
                    cmd.Parameters.Add(new MySqlParameter("@geburtsdatum", MySqlDbType.Date) { Value = neuestier.Geburtsdatum });
                    cmd.Parameters.Add(new MySqlParameter("@geschlecht", MySqlDbType.VarChar,1) { Value = neuestier.Geschlecht });
                    cmd.Parameters.Add(new MySqlParameter("@beschreibung", MySqlDbType.VarChar,300) { Value = neuestier.Beschreibung });
                    cmd.Parameters.Add(new MySqlParameter("@fundtier", MySqlDbType.Int32) { Value = neuestier.Fundtier });
                    cmd.Parameters.Add(new MySqlParameter("@fk_tierrasse_tier", MySqlDbType.Int64) { Value = neuestier.FK_Tierrasse_Tier });

                    cmd.ExecuteNonQuery();
                    neuestier.ID_Tier = (int)cmd.LastInsertedId;
                }

            }
        }

        public static void DeleteTier(int tierid)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();


                sqlstatement = "DELETE FROM tier WHERE ID_Tier = " + tierid;


                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.ExecuteNonQuery();
                }


            }
        }
    }
    
}
