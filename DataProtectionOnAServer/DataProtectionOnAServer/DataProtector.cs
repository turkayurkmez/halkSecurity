using System.Security.Cryptography;
using System.Text;

namespace DataProtectionOnAServer
{
    public class DataProtector
    {
        /*
         * Uygulamada çok kritik bir veri olabilir. Bunlara SADECE UYGULAMANIN ERİŞMESİ için gizlemeniz gerekir.
         * 1. Verileri doğrudan Encryption - Decryption
         * 2. Dosyaları encrypt etmek
         */

        /*
         * https://learn.microsoft.com/en-us/aspnet/core/security/data-protection/using-data-protection?view=aspnetcore-7.0
         */

        private string path;
        private byte[] entropy;

        public DataProtector(string path)
        {
            this.path = path;
            entropy = new byte[16];
            entropy = RandomNumberGenerator.GetBytes(16);
            this.path += "EncryptedData.halk";
        }

        public int EncryptData(string criticalData)
        {
            var encoded = Encoding.UTF8.GetBytes(criticalData);
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            int length = encryptDataToFile(encoded, entropy, DataProtectionScope.CurrentUser, fileStream);
            fileStream.Close();
            return length;
        }

        private int encryptDataToFile(byte[] encoded, byte[] entropy, DataProtectionScope currentUser, FileStream fileStream)
        {
            byte[] encryptedAta = ProtectedData.Protect(encoded, entropy, currentUser);
            int outputLength = 0;

            if (fileStream.CanWrite && encryptedAta != null)
            {
                fileStream.Write(encryptedAta, 0, encryptedAta.Length);
                outputLength += encryptedAta.Length;
            }
            return outputLength;

        }

        public string DecryptData(int length)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            byte[] decrytedData = decryptDataFromFile(fileStream, entropy, DataProtectionScope.CurrentUser, length);
            fileStream.Close();
            return Encoding.UTF8.GetString(decrytedData);
        }

        private byte[] decryptDataFromFile(FileStream fileStream, byte[] entropy, DataProtectionScope currentUser, int length)
        {
            byte[] inputBuffer = new byte[length];
            byte[] outputBuffer;

            if (fileStream.CanRead)
            {
                fileStream.Read(inputBuffer, 0, inputBuffer.Length);
                outputBuffer = ProtectedData.Unprotect(inputBuffer, entropy, currentUser);

            }
            else
            {
                throw new IOException("Stream okunamıyor!!!");
            }

            return outputBuffer;
        }
    }
}
