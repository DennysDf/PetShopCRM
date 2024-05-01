using System.Globalization;

public static class ParseDecimal
{
    public static decimal StringToDecimal(this string value) => decimal.Parse(value, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"));
    public static decimal StringLiteralToDecimal(this string value) => decimal.Parse(value[..^2] + "." + value[^2..]);
}
