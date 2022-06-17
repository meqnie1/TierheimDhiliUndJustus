namespace TierheimDhiliUndJustus.DAL
{
    using System.Drawing;
    using TierheimDhiliUndJustus.BLL;
    using System.Data.SqlClient;
    using System.IO;
    using MySql.Data.MySqlClient;

    public static class Tierart_DA
    {
        public static string sqlstatement = "";

        public static List<Tierart> GetTierarten()
        {
            List<Tierart> lst_tierarten = new List<Tierart>();

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

                            lst_tierarten.Add(tierart);
                        }

                    }
                }

            }
            return lst_tierarten;
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

        public static int GetTierartID(string tierartname)
        {
            int tierart_id = 0;

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
                            tierart_id = (int)reader["ID_Tierart"];
                        }
                    }
                }
            }
            return tierart_id;
        }
    } 
}
