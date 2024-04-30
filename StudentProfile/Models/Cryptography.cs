using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace StudentProfile.Models
{
    public static class Cryptography
    {
        public static byte[] Encode(string password)
        {
            byte[] data = Encoding.ASCII.GetBytes(password);

            using (SHA256 mySHA256 = SHA256.Create())
            {
                return mySHA256.ComputeHash(data);
            }
        }
    }
}