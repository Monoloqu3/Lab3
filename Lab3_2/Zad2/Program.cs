using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

class EncryptionPerformance
{
    static void Main(string[] args)
    {
        SymmetricAlgorithm[] algorithms = {
            new AesCryptoServiceProvider { KeySize = 128 },
            new AesCryptoServiceProvider { KeySize = 256 },
            new AesManaged { KeySize = 128 },
            new AesManaged { KeySize = 256 },
            new RijndaelManaged { KeySize = 128 },
            new RijndaelManaged { KeySize = 256 },
            new DESCryptoServiceProvider(),
            new TripleDESCryptoServiceProvider()
        };

        Console.WriteLine("Algorytm | Rozmiar klucza | Czas (s) na blok | Bajty/s (RAM) | Bajty/s (HDD)");

        foreach (var algorithm in algorithms)
        {
            // Pomiar dla strumienia z pamięci operacyjnej
            var ramResult = MeasureEncryptionPerformance(algorithm, true);

            // Pomiar dla strumienia z dysku twardego
            var hddResult = MeasureEncryptionPerformance(algorithm, false);

            Console.WriteLine($"{algorithm.GetType().Name} | {algorithm.KeySize} bit | {ramResult.Item1} | {ramResult.Item2} | {hddResult.Item2}");
        }
    }

    static Tuple<double, double> MeasureEncryptionPerformance(SymmetricAlgorithm algorithm, bool useRAM)
    {
        // Inicjalizacja danych i stopera
        byte[] dataBlock = new byte[algorithm.BlockSize / 8];
        Stopwatch stopwatch = new Stopwatch();
        double timePerBlock, bytesPerSecond;

        // Ustawienie strumienia
        Stream stream = useRAM ? (Stream)new MemoryStream() : new FileStream("testfile.dat", FileMode.Create, FileAccess.Write);

        try
        {
            // Szyfrowanie danych
            ICryptoTransform encryptor = algorithm.CreateEncryptor();
            CryptoStream cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write);

            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                cryptoStream.Write(dataBlock, 0, dataBlock.Length);
            }
            stopwatch.Stop();

            timePerBlock = stopwatch.Elapsed.TotalSeconds / 1000;
            bytesPerSecond = (dataBlock.Length * 1000) / stopwatch.Elapsed.TotalSeconds;
        }
        finally
        {
            stream.Close();
        }

        return new Tuple<double, double>(timePerBlock, bytesPerSecond);
    }
}
