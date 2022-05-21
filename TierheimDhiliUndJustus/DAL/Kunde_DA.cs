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
        
        public static List<Kunde> CreateKunde()
        {

        }
    }
}
