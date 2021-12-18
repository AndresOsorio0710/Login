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
        private MD5Generate mD5Generate;
        public LogicUser(){
            this.mD5Generate = new MD5Generate();
        }
        public string GetMD5(string _password)
        {
            return this.mD5Generate.GetMD5(_password);
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
            foreach (char s in _str)
            {
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