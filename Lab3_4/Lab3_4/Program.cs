using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class RSAFileEncryption
{
    static void Main(string[] args)
    {
        using (var rsa = new RSACryptoServiceProvider(2048))
        {
            try
            {
                var publicKey = rsa.ToXmlString(false);
                File.WriteAllText("public_key.xml", publicKey);

                var privateKey = rsa.ToXmlString(true);
                File.WriteAllText("private_key.xml", privateKey);
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }

        string publicKeyText = File.ReadAllText("public_key.xml");
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(publicKeyText);

            EncryptFile("plaintext.txt", "encrypted.txt", rsa);
        }

        string privateKeyText = File.ReadAllText("private_key.xml");
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(privateKeyText);

            DecryptFile("encrypted.txt", "decrypted.txt", rsa);
        }
    }

    static void EncryptFile(string inputFile, string outputFile, RSACryptoServiceProvider rsa)
    {
        using (FileStream inputStream = File.Open(inputFile, FileMode.Open))
        using (FileStream outputStream = File.Create(outputFile))
        {
            byte[] inputBytes = new byte[inputStream.Length];
            inputStream.Read(inputBytes, 0, inputBytes.Length);
            byte[] encryptedBytes = rsa.Encrypt(inputBytes, false);
            outputStream.Write(encryptedBytes, 0, encryptedBytes.Length);
        }
        Console.WriteLine("Plik zaszyfrowany.");
    }

    static void DecryptFile(string inputFile, string outputFile, RSACryptoServiceProvider rsa)
    {
        using (FileStream inputStream = File.Open(inputFile, FileMode.Open))
        using (FileStream outputStream = File.Create(outputFile))
        {
            byte[] encryptedBytes = new byte[inputStream.Length];
            inputStream.Read(encryptedBytes, 0, encryptedBytes.Length);
            byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, false);
            outputStream.Write(decryptedBytes, 0, decryptedBytes.Length);
        }
        Console.WriteLine("Plik odszyfrowany.");
    }
}
