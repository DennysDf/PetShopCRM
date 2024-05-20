using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class CryptographyHelper
{
    // Chaves RSA
    private static RSAParameters _publicKey;
    private static RSAParameters _privateKey;

    // Chave AES
    private static byte[] _aesKey;
    private static byte[] _aesIV;

    // Inicialização das chaves e IV
    static CryptographyHelper()
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            _publicKey = rsa.ExportParameters(false);
            _privateKey = rsa.ExportParameters(true);
        }

        using (Aes aesAlg = Aes.Create())
        {
            _aesKey = aesAlg.Key;
            _aesIV = aesAlg.IV;
        }
    }

    // Método para criptografar um número usando RSA e retornar como Base64
    public static string EncryptNumberAsBase64(this int number)
    {
        byte[] encryptedBytes = EncryptNumber(number, _publicKey);
        return UrlEncodeBase64(Convert.ToBase64String(encryptedBytes));
    }

    // Método para decriptografar um número usando RSA a partir de Base64
    public static int DecryptNumberFromBase64(this string encryptedBase64)
    {
        string decodedBase64 = UrlDecodeBase64(encryptedBase64);
        byte[] encryptedBytes = Convert.FromBase64String(decodedBase64);
        return DecryptNumber(encryptedBytes, _privateKey);
    }

    // Método para criptografar uma string usando AES e retornar como Base64
    public static string EncryptStringAsBase64(this string plainText)
    {
        byte[] encryptedBytes = EncryptString(plainText, _aesKey, _aesIV);
        return UrlEncodeBase64(Convert.ToBase64String(encryptedBytes));
    }

    // Método para decriptografar uma string usando AES a partir de Base64
    public static string DecryptStringFromBase64(this string encryptedBase64)
    {
        string decodedBase64 = UrlDecodeBase64(encryptedBase64);
        byte[] encryptedBytes = Convert.FromBase64String(decodedBase64);
        return DecryptString(encryptedBytes, _aesKey, _aesIV);
    }

    // Método para criptografar um número usando RSA
    private static byte[] EncryptNumber(int number, RSAParameters publicKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(publicKey);
            byte[] dataToEncrypt = BitConverter.GetBytes(number);
            return rsa.Encrypt(dataToEncrypt, true);
        }
    }

    // Método para decriptografar um número usando RSA
    private static int DecryptNumber(byte[] encryptedData, RSAParameters privateKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(privateKey);
            byte[] decryptedData = rsa.Decrypt(encryptedData, true);
            return BitConverter.ToInt32(decryptedData, 0);
        }
    }

    // Método para criptografar uma string usando AES
    private static byte[] EncryptString(string plainText, byte[] key, byte[] iv)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }
    }

    // Método para decriptografar uma string usando AES
    private static string DecryptString(byte[] cipherText, byte[] key, byte[] iv)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }

    // Métodos auxiliares para codificação e decodificação de Base64 para URLs
    private static string UrlEncodeBase64(string base64)
    {
        return base64.Replace('+', '-').Replace('/', '_').Replace('=', ',');
    }

    private static string UrlDecodeBase64(string base64)
    {
        return base64.Replace('-', '+').Replace('_', '/').Replace(',', '=');
    }
}
