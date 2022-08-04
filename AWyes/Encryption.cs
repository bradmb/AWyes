using System.Security.Cryptography;
using System.Text;

namespace AWyes
{
    internal static class Encryption
    {
        /// <summary>
        /// If the key is too short, pad it to make it work
        /// </summary>
        /// <param name="key">The key/passprhase</param>
        /// <returns>The padded key</returns>
        private static string PadKey(string key)
        {
            return key.PadRight(32, 'f');
        }

        /// <summary>
        /// Encrypts a string using AES
        /// </summary>
        /// <param name="plainText">Plaintext string value</param>
        /// <param name="key">Key string value</param>
        /// <param name="iV">IV string value</param>
        /// <returns>An encrypted value of the string</returns>
        internal static string EncryptLocal(string plainText, string key, string iV)
        {
            if (string.IsNullOrWhiteSpace(plainText))
            {
                return plainText;
            }

            key = PadKey(key);

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] iVBytes = Encoding.UTF8.GetBytes(iV);

            var output = EncryptStringToBytes_Aes(plainText, keyBytes, iVBytes);

            return Convert.ToBase64String(output);
        }

        /// <summary>
        /// Encrypts a string using AES
        /// </summary>
        /// <param name="plainText">Plaintext string value</param>
        /// <param name="key">Key byte array value</param>
        /// <param name="iV">IV byte array value</param>
        /// <returns>An encrypted value of the string in bytes</returns>
        private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iV)
        {
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using var msEncrypt = new MemoryStream();
                using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    // Write all data to the stream.
                    swEncrypt.Write(plainText);
                }

                encrypted = msEncrypt.ToArray();
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        /// <summary>
        /// Decrypts a string
        /// </summary>
        /// <param name="value">Encrypted string value</param>
        /// <param name="key">Key string value</param>
        /// <param name="iV">IV string value</param>
        /// <returns>The decrypted value of the string</returns>
        internal static string DecryptLocal(string value, string key, string iV)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            key = PadKey(key);

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] iVBytes = Encoding.UTF8.GetBytes(iV);

            var valueBytes = Convert.FromBase64String(value);
            return DecryptStringFromBytes_Aes(valueBytes, keyBytes, iVBytes);
        }

        /// <summary>
        /// Decrypts a string
        /// </summary>
        /// <param name="cipherText">A byte array of the encrypted value</param>
        /// <param name="key">A byte array of the Key value</param>
        /// <param name="iV">A byte array of the IV value</param>
        /// <returns>Decryptrd value</returns>
        private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] iV)
        {
            // Declare the string used to hold
            // the decrypted text.
            string? plainText = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using var msDecrypt = new MemoryStream(cipherText);
                using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using (var srDecrypt = new StreamReader(csDecrypt))
                {
                    // Read the decrypted bytes from the decrypting stream
                    // and place them in a string.
                    plainText = srDecrypt.ReadToEnd();
                }
            }

            return plainText;
        }
    }
}