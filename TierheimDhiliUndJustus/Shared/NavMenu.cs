namespace TierheimDhiliUndJustus.Shared
{
    public partial class NavMenu
    {
        public static void Abmelden()
        {

            if (LoginConfig.Angemeldet != 0)
            {
                LoginConfig.Angemeldet = 0;
                link = "Login";
                link2 = "Login";
                Status = "Anmelden";
                

            }
        }
    }
}
