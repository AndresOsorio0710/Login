using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace backend.Logic
{
    public class LogicUser
    {
        private Boolean containNumbers;
        private Boolean containLowercase;
        private Boolean containCapitalLetters;
        public string GetMD5(string _password)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder password = new StringBuilder();
            stream = md5.ComputeHash(aSCIIEncoding.GetBytes(_password));
            for (int i = 0; i < stream.Length; i++) password.AppendFormat("{0:x2}", stream[i]);
            return password.ToString();
        }

        public string VlidatePassword(string _password)
        {
            if (_password.Contains(" "))
            {
                return "Blanks are not allowed.";
            }
            if (_password.Length < 8)
            {
                return "Is required min 8 characters.";
            }
            ValidateCharacters(_password);
            if (!containNumbers)
            {
                return "At least one number is required.";
            }
            if (!containLowercase)
            {
                return "At least one lowercase letter is required..";
            }
            if (!containCapitalLetters)
            {
                return "At least one capital letter is required..";
            }
            return "Ok";
        }

        public void ValidateCharacters(string _str)
        {
            containNumbers = false;
            containLowercase = false;
            containCapitalLetters = false;
            string[] str = _str.Split("");
            for (int i = 0; i < str.Length; i++)
            {
                /*if (Regex.IsMatch(_str.Substring(i, i + 1), @"^[a-z]+$"))
                {
                    containLowercase = true;
                }
                if (Regex.IsMatch(_str.Substring(i, i + 1), @"^[A-Z]+$"))
                {
                    containCapitalLetters = true;
                }
                if (Regex.IsMatch(_str.Substring(i, i + 1), @"^[0-9]+$"))
                {
                    containNumbers = true;
                }*/
                Console.WriteLine("\n" + i + " " + (i + 1) + " " + str[i]);
            }
            foreach (char s in _str)
            {
                Console.WriteLine("\n" + s);
                if (Regex.IsMatch(s.ToString(), @"^[a-z]+$"))
                {
                    containLowercase = true;
                }
                if (Regex.IsMatch(s.ToString(), @"^[A-Z]+$"))
                {
                    containCapitalLetters = true;
                }
                if (Regex.IsMatch(s.ToString(), @"^[0-9]+$"))
                {
                    containNumbers = true;
                }
            }
        }
    }
}