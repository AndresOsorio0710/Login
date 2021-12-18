using System.Security.Cryptography;
using System.Text;

namespace backend.Logic
{
    public class MD5Generate
    {
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
    }
}