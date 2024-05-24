using System.Globalization;

public static class DateToBrazil
{
    public static string ToDateBrazil(this DateTime date) => date.ToString(CultureInfo.GetCultureInfo("pt-BR"));

    public static string ToDateBrazilMin(this DateTime date) => date.ToString("dd/MM/yyyy");

    public static DateTime ToDateTime(this string date) => DateTime.Parse(date, CultureInfo.GetCultureInfo("pt-BR"));

}
