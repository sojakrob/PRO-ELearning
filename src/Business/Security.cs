using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ELearning.Business
{
    internal class Security
    {
        public static string GetPasswordHash(string password)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] outputBytes = provider.ComputeHash(inputBytes);

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (byte b in outputBytes)
                builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }
    }
}
