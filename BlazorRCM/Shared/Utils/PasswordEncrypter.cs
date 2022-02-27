using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.Utils
{
    public class PasswordEncrypter
    {
        public static String Encrypt(String Password)
        {
            // Kendi algoritmanızı kullanabilirsiniz.
            // Ben Base64 olarak kullanıyorum


            var plainTextBytes = Encoding.UTF8.GetBytes(Password);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static String Decrypt(String EncryptedPassword)
        {
            // Kendi algoritmanızı kullanabilirsiniz.
            // Ben Base64 olarak kullanıyorum

            byte[] data = Convert.FromBase64String(EncryptedPassword);
            string decodedString = Encoding.UTF8.GetString(data);

            return decodedString;
        }
    }
}
