using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace MvcApplication5.Models
{
    public class User
    {
        private string Username, hashedPassword;
        public User(string username, string password)
        {
            Username = username;
            RNGCryptoServiceProvider salt = new RNGCryptoServiceProvider();
            hashedPassword = this.HashPassword(password, salt.ToString());
        }

        private string HashPassword(string password, string salt)
        {
            string combine = password + salt;
            byte[] saltedHash = Encoding.UTF8.GetBytes(combine);
            HashAlgorithm alg = new SHA256Managed();
            byte[] hash = alg.ComputeHash(saltedHash);
            return Convert.ToBase64String(hash);
        }
    }
}