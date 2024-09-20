namespace SoccerShoesShop.Common
{
    public class DateHelper
    {
        public static DateOnly GetCurrentDate()
        {
            return DateOnly.FromDateTime(DateTime.Now);
        }


        public static DateOnly AddThreeDays(int d)
        {
            DateOnly currentDate = GetCurrentDate();
            return currentDate.AddDays(d);
        }
    }
}
