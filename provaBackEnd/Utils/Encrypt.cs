using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace provaBackEnd.Utils
{
    public static class Encrypt
    {
        public static string EncryptPassword(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }

            StringBuilder response = new StringBuilder();
            MD5 md5Hash = MD5.Create();
            //Convert the input string to a byte array and compute the hash
            byte[] buffer = Encoding.UTF8.GetBytes(input);
            byte[] data = md5Hash.ComputeHash(buffer);
            for (int i = 0; i < data.Length; i++)
            {
                response.Append(data[i].ToString("x2"));
            }
            return response.ToString();
        }
    }
}
