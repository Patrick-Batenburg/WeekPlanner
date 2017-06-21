using System;
using System.Security.Cryptography;
using System.Text;

namespace SamenSterkOnline.Providers
{
    public class EncryptionProvider
    {
        /// <summary>
        /// Compute hash for string encoded as UTF8
        /// </summary>
        /// <param name="value">String to encrypt.</param>
        /// <returns>40-character hex string.</returns>
        public static string Encrypt(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value + Properties.Settings.Default.Salt);

            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return HexStringFromBytes(hashBytes);
        }

        /// <summary>
        /// Convert an array of bytes to a string of hex digits
        /// </summary>
        /// <param name="bytes">array of bytes</param>
        /// <returns>String of hex digits</returns>
        public static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}