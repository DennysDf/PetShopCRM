using System.Security.Cryptography;
using System.Text;

public static class CryptographyHelper
{
    private static readonly byte[] _key;
    private static readonly byte[] _iv;

    static CryptographyHelper()
    {
        string keyBase = "ZyCode";
        string ivBase = "Pet";

        string datePart = DateTime.UtcNow.ToString("yyyy");

        _key = GenerateKey(keyBase + datePart);
        _iv = GenerateIV(ivBase + datePart);
    }

    public static string Encrypt(this int value) => Encrypt(value.ToString());
    public static int DecryptToInt(this string cipherText) => int.Parse(Decrypt(cipherText) ?? "0");

    public static string Encrypt(this string plainText)
    {
        plainText = plainText.PadRight(64, '|');

        using Aes aesAlg = Aes.Create();
        aesAlg.Key = _key;
        aesAlg.IV = _iv;

        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using MemoryStream msEncrypt = new();
        using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
        using (StreamWriter swEncrypt = new(csEncrypt))
        {
            swEncrypt.Write(plainText);
        }

        return UrlEncodeBase64(Convert.ToBase64String(msEncrypt.ToArray()));
    }

    public static string? Decrypt(this string cipherText)
    {
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = _key;
        aesAlg.IV = _iv;

        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        using MemoryStream msDecrypt = new(Convert.FromBase64String(UrlDecodeBase64(cipherText)));
        using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
        using StreamReader srDecrypt = new(csDecrypt);

        var decodedText = srDecrypt.ReadToEnd().TrimEnd('|');

        if (decodedText.Contains('�'))
            return null;

        return decodedText;
    }

    private static byte[] GenerateKey(string keySource)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(keySource));
        }
    }

    private static byte[] GenerateIV(string ivSource)
    {
        using (MD5 md5 = MD5.Create())
        {
            return md5.ComputeHash(Encoding.UTF8.GetBytes(ivSource));
        }
    }

    private static string ConvertToBase64(string text)
    {
        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        return Convert.ToBase64String(textBytes);
    }

    private static string UrlEncodeBase64(string base64)
    {
        return base64.Replace('+', '-').Replace('/', '_').Replace('=', ',');
    }

    private static string UrlDecodeBase64(string base64)
    {
        return base64.Replace('-', '+').Replace('_', '/').Replace(',', '=');
    }
}
