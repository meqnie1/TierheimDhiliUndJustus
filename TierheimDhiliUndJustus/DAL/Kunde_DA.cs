namespace TierheimDhiliUndJustus.DAL
{
    using MySql.Data.MySqlClient;
    using TierheimDhiliUndJustus.BLL;

    public static class Kunde_DA
    {
        
        public static List<Kunde> GetKunden()
        {
            List<Kunde> lst_kunden = new List<Kunde>();

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

                            lst_kunden.Add(kunde);
                        }
                    }
                }
            }
            return lst_kunden;

        }

        public static Kunde GetOneKunde(int kunde_id)
        {
            Kunde kunde = new Kunde();

            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM kunde WHERE ID_Kunde = @kundeid", conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@kundeid", MySqlDbType.Int32) { Value = kunde_id });

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                                kunde = new Kunde(
                                (int)reader["ID_Kunde"],
                                (string)reader["Email"],
                                (string)reader["Passwort"],
                                (string)reader["Rolle"]);
                          
                        }
                    }
                }
            }
            return kunde;

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

        public static void UpdateKunde(int kunde_id, string email, string passwort)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();

                string sqlstatement = "UPDATE kunde SET Email = @email ,Passwort = @passwort WHERE ID_Kunde = " + kunde_id;

                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@email", MySqlDbType.VarChar, 100) { Value = email });
                    cmd.Parameters.Add(new MySqlParameter("@passwort", MySqlDbType.VarChar, 45) { Value = passwort });
           
                    cmd.ExecuteNonQuery();
                    
                }

            }
        }

        public static void DeleteKunde(int kunde_id)
        {
            using (MySqlConnection conn = new MySqlConnection(Config.CONNSTRING))
            {
                conn.Open();

                string sqlstatement = "DELETE FROM kunde WHERE ID_Kunde = @kundeid";

                using (MySqlCommand cmd = new MySqlCommand(sqlstatement, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@kundeid", MySqlDbType.Int32) { Value = kunde_id });

                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
