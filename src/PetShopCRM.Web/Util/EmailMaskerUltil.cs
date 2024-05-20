using System;

namespace EmailHelper
{
    public static class EmailMaskerUltil
    {
        public static string MaskEmail(this string email)
        {
            // Localizar o índice do caractere '@'
            int atIndex = email.IndexOf('@');
            if (atIndex < 0)
            {
                throw new ArgumentException("O e-mail fornecido não é válido.");
            }

            // Separar o nome de usuário e o domínio
            string username = email.Substring(0, atIndex);
            string domain = email.Substring(atIndex);

            // Manter os três primeiros caracteres do nome de usuário
            string visiblePart = username.Substring(0, Math.Min(3, username.Length));
            string maskedPart = new string('*', username.Length - visiblePart.Length);

            // Concatenar as partes visíveis e mascaradas com o domínio
            string maskedEmail = $"{visiblePart}{maskedPart}{domain}";

            return maskedEmail;
        }
    }
}
