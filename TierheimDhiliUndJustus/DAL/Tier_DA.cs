namespace TierheimDhiliUndJustus.DAL
{
    using MySqlConnector;
    using System.Drawing;
    using TierheimDhiliUndJustus.BLL;
    using MySql.Data;


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

                            byte[] rawData;
                            FileStream fs;
                            UInt32 FileSize = reader.GetUInt32(reader.GetOrdinal((string)reader[5]));
                            rawData = new byte[FileSize];

                            reader.GetBytes(reader.GetOrdinal("file"), 0, rawData, 0, (int)FileSize);

                            fs = new FileStream(@"C:\newfile.png", FileMode.OpenOrCreate, FileAccess.Write);
                            fs.Write(rawData, 0, (int)FileSize);
                            fs.Close();

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
    }  
}
