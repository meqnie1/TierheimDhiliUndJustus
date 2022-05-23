namespace TierheimDhiliUndJustus.DAL

{
    using MySqlConnector;
    using TierheimDhiliUndJustus.BLL;

    public class Kunde_DA
    {
        public static List<Kunde> lstkunde = new List<Kunde>();

        public static List<Kunde> GetKunde()
        {
     
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM kunde", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Kunde kunde = new Kunde(
                                (int)reader["ID_Kunde"],
                                (string)reader["Email"],
                                (string)reader["Passwort"],
                                (string)reader["Rolle"]);

                            lstkunde.Add(kunde);
                        }
                    }
                }
            }
            return lstkunde;

        }

        public static void InsertKunde(Kunde neuerKunde)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();

                string sqlstatement = "INSERT INTO kunde(Email, Passwort, Rolle) VALUES(@email,@passwort,@rolle)";

                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@email", MySqlDbType.VarChar, 100) { Value = neuerKunde.Email });
                    cmd.Parameters.Add(new MySqlParameter("@passwort", MySqlDbType.VarChar, 45) { Value = neuerKunde.Passwort });
                    cmd.Parameters.Add(new MySqlParameter("@rolle", MySqlDbType.VarChar, 10) { Value = neuerKunde.Rolle });

                    cmd.ExecuteNonQuery();
                    neuerKunde.ID_Kunde = (int)cmd.LastInsertedId;
                }

            }
        }
    }
}
