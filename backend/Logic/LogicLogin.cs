namespace backend.Logic
{
    public class LogicLogin
    {
        private MD5Generate mD5Generate;
        public LogicLogin()
        {
            this.mD5Generate = new MD5Generate();
        }
        public string GetMD5(string _password)
        {
            return this.mD5Generate.GetMD5(_password);
        }
    }
}