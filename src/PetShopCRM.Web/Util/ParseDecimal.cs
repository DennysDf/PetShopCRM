public static class ParseDecimal
{
    public static decimal StringToDecimal(this string value) => decimal.Parse(value.Replace(".", "").Replace(",", "."));
    public static decimal StringLiteralToDecimal(this string value) => decimal.Parse(value[..^2] + "." + value[^2..]);
}
