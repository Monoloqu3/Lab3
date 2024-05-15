using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Zad1
{
    public partial class Form1 : Form
    {

        private SymmetricAlgorithm algorithm;
        private Stopwatch encryptionStopwatch;
        private Stopwatch decryptionStopwatch;
        private byte[] encrypted;
        private string decrypted;
        private byte[] key;
        private byte[] iv;
        private int key_size;
        private int ivSize;

        public Form1()
        {
            InitializeComponent();
            algorithmComboBox.Items.AddRange(new object[] { "AES", "DES", "TripleDES" });
            encryptionStopwatch = new Stopwatch();
            decryptionStopwatch = new Stopwatch();
        }

        private void algorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (algorithmComboBox.SelectedItem.ToString())
            {
                case "AES":
                    key_size = 32;
                    ivSize = 16;
                    algorithm = Aes.Create();
                    break;
                case "DES":
                    key_size = 8;
                    ivSize = 8;
                    algorithm = DES.Create();
                    break;
                case "TripleDES":
                    key_size = 24;
                    ivSize = 8;
                    algorithm = TripleDES.Create();
                    break;
                default:
                    key_size = 32;
                    ivSize = 16;
                    algorithm = Aes.Create();
                    break;

            }
            generateKey(sender, e, key_size, ivSize);

        }

        private void generateKey(object sender, EventArgs e, int key_size, int iv_size)
        {
            algorithm.GenerateKey();
            keyTextBox.Text = BitConverter.ToString(algorithm.Key).Replace("-", "");
            key = Encoding.UTF8.GetBytes(keyTextBox.Text);
            algorithm.GenerateIV();
            ivTextBox.Text = BitConverter.ToString(algorithm.IV).Replace("-", "");
            iv = Encoding.UTF8.GetBytes(ivTextBox.Text);

            Array.Resize(ref key, key_size);
            Array.Resize(ref iv, iv_size);
        }

        private void generateKeyIVButton_Click(object sender, EventArgs e)
        {
            generateKey(sender, e, key_size, ivSize);
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            encryptionStopwatch.Restart();
            encrypted = EncryptStringToBytes_Aes(plainTextBox.Text, key, iv);
            encryptionStopwatch.Stop();

            AsciiTextBox.Text = Encoding.ASCII.GetString(encrypted);
            HexTextBox.Text = BitConverter.ToString(encrypted).Replace("-", "");
            encryptionTimeLabel.Text = $"Encryption Time: {encryptionStopwatch.ElapsedMilliseconds} ms";
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            decryptionStopwatch.Restart();
            decrypted = DecryptStringFromBytes_Aes(encrypted, key, iv);
            decryptionStopwatch.Stop();
            byte[] asciiBytes = Encoding.ASCII.GetBytes(decrypted);
            AsciiTextBox.Text = decrypted;
            HexTextBox.Text = BitConverter.ToString(asciiBytes); 
            decryptionTimeLabel.Text = $"Decryption Time: {decryptionStopwatch.ElapsedMilliseconds} ms";
        }

        private byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (algorithm.Key == null)
                throw new ArgumentNullException("Key");
            if (algorithm.IV == null)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = algorithm.CreateEncryptor(Key, IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        private string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (algorithm.Key == null)
                throw new ArgumentNullException("Key");
            if (algorithm.IV == null)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = algorithm.CreateDecryptor(Key, IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            

            return plaintext;
        }
    }
}
