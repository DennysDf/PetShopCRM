public static class DateToBrazil
{
    public static string ToDateBrazil(this DateTime date) => date.ToString(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));

    public static string ToDateBrazilMin(this DateTime date) => date.ToString("dd/MM/yyyy");
}
