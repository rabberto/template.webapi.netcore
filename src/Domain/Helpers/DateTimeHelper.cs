namespace Template.Webapi.Netcore.Domain.Helpers;

public class DateTimeHelper
{
    public static string GetYearMonthDayToString()
        => @$"{DateTime.Now.Year.ToString().PadLeft(4, '0')}
                  {DateTime.Now.Month.ToString().PadLeft(2, '0')}
                  {DateTime.Now.Day.ToString().PadLeft(2, '0')}";

    public static string GetYearMonthToString()
        => @$"{DateTime.Now.Year.ToString().PadLeft(4, '0')}
                  {DateTime.Now.Month.ToString().PadLeft(2, '0')}";

    public static string GetDateTimeToString()
        => DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff");
}