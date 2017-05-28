using System.Text;

namespace Helpers
{
    public static class Security
    {
        private static readonly string _guid = "cf1b4906-f809-4abe-a7b8-ba6c3e218e6a";

        /// <summary>
        /// Criptografa a string informada
        /// </summary>
        /// <param name="decryptedValue"></param>
        /// <returns>String criptografada</returns>
        public static string Encrypt(string decryptedValue)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(decryptedValue + _guid);

            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
