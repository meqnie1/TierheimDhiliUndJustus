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

        public static void CreateTierart(Tierart tierart)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();

                string sqlstatement = "INSERT INTO tierart(`Tierartname`) VALUES (@tierartname)";

                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@tierartname", MySqlDbType.VarChar, 25) { Value = tierart.Tierartname });

                    cmd.ExecuteNonQuery();
                    tierart.ID_Tierart = (int)cmd.LastInsertedId;
                }
            }
        }

        public static int GetTierartid(string tierartname)
        {
            List<Tierart> tierartlist = new List<Tierart>();
            string sqlstatement = "";
            int tierartid = 0;

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();

                sqlstatement = "SELECT ID_Tierart FROM tierart WHERE tierart.Tierartname = @tierartname";



                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@tierartname", MySqlDbType.VarChar, 25) { Value = tierartname });

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tierartid = (int)reader["ID_Tierart"];
                        }
                    }
                }
            }
            return tierartid;
        }
    } 
}
