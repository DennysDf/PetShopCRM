using System.Text.RegularExpressions;

public static class CPFUtil
{
    public static string ExtractCpfNumbers(this string input)
    {
        // Define a expressão regular para o formato de CPF
        string cpfPattern = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
        if (Regex.IsMatch(input, cpfPattern))
        {
            // Remove os caracteres de formatação (pontos e hífen)
            string onlyNumbers = Regex.Replace(input, @"\D", "");
            return onlyNumbers;
        }
        else
        {
            // Retorna a string original se não corresponder ao formato de CPF
            return input;
        }
    }
    public static string FormatCpf(this string input)
    {
        // Verifica se a string possui exatamente 11 dígitos
        if (input.Length == 11 && Regex.IsMatch(input, @"^\d{11}$"))
        {
            // Formata a string como CPF
            return $"{input.Substring(0, 3)}.{input.Substring(3, 3)}.{input.Substring(6, 3)}-{input.Substring(9, 2)}";
        }
        else
        {
            // Retorna a string original se não tiver 11 dígitos
            return input;
        }
    }
}
