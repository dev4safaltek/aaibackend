using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AAI.Common
{
    public class PasswordSHA512CryptoProvider
    {
        public static string CreateHash(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Password can't be null");
            }
            //if (string.IsNullOrEmpty(passwordSalt))
            //{
            //    throw new Exception("Please provide salt for hashing. Salt should not be null.");
            //}
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password).ToArray());

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public static bool ValidatePassword(string password, string passwordHash)
        {
            return CreateHash(password).Equals(passwordHash);
        }

        public static string CreateSalt()
        {
            byte[] randomArray = new byte[24];
            string randomString;
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomArray);
            randomString = Convert.ToBase64String(randomArray);

            return randomString;
        }

    }
}
