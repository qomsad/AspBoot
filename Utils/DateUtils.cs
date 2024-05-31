namespace AspBoot.Utils;

public static class DateUtils
{
    public static bool IsLast(this DateTime? time, int minutes)
    {
        if (time == null)
        {
            return false;
        }
        var t1 = (DateTime) time;
        return DateTime.Now.ToUniversalTime().Subtract(t1).Minutes <= minutes;
    }
}
