namespace SoccerShoesShop.Common
{
    public static class IdGenerator
    {
        public static int GeneratedIdBasedOnTime()
        {
            DateTime now = DateTime.Now;
            string hour = now.Hour.ToString("D2");
            string minute = now.Minute.ToString("D2");
            string second = now.Second.ToString("D2");
            int id = int.Parse($"{hour}{minute}{second}");
            int idPreventive = int.Parse($"{minute}{second}");
            if (id > int.MaxValue)
                return idPreventive;
            return id;
        }
    }
}
