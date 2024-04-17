public static class ParseDecimal
{
    public static decimal StringToDecimal(this string value) => decimal.Parse(value.Replace(".", "").Replace(",", "."));

}
