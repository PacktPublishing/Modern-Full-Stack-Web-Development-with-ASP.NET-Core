using System.Security.Cryptography;
using System.Text;

namespace Authentication.Helpers
{
    public class EncryptionHelper
    {
        public static string EncryptString(string text, string keyString)
        {

            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {

                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))

                {

                    using (var msEncrypt = new MemoryStream())

                    {

                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))

                        {

                            using (var swEncrypt = new StreamWriter(csEncrypt))

                            {

                                swEncrypt.Write(text);

                            }

                        }



                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);

                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);



                        return Convert.ToBase64String(result);

                    }

                }

            }

        }
    }
}
