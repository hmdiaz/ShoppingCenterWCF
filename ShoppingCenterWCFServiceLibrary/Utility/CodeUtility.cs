using System;
using System.Security.Cryptography;
using System.Text;

namespace ShoppingCenterWCFServiceLibrary.Utility
{
    public static class CodeUtility
    {
        public static Guid GetConfirmationCode()
        {
            return Guid.NewGuid();
        }

        public static string GetMd5(string sourceString)
        {
            byte[] source, result;

            source = System.Text.Encoding.UTF8.GetBytes(sourceString);

            using (MD5 md5 = MD5.Create())
            {
                result = md5.ComputeHash(source);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var b in result)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}