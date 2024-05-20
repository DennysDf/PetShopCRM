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
}
