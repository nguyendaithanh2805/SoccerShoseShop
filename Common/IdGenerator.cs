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
            return id;
        }
    }
}
