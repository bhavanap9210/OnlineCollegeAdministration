/// Symmetric (Same) key AES Algorithm for Encryption and Decryption
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Helper
{
    public static class EncryptDecrypt
    {
        
        /// <summary>
        ///  Encrypts the text 
        ///  Firstly the original text i.e. clear text is converted into bytes and then for the 
        ///  AES algorithm to perform encryption, we need to generate Key and IV using the derived 
        ///  bytes and the symmetric key.
        ///  Using MemoryStream and CryptoStream the clear text is encrypted and written to byte 
        ///  array and finally the byte array is converted to Base64String and returned which is the
        ///  final outcome i.e. the corresponding encrypted text.
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns>string</returns>
        public static string Encrypt(string clearText)
        {
            string _encryptionKey = System.Configuration.ConfigurationManager.AppSettings["EncryptionKey"].ToString();
            string EncryptionKey = _encryptionKey;
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            string encryptedString = string.Empty;
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptedString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptedString;
        }


        /// <summary>
        ///  Firstly the encrypted text i.e. cipher text is converted into bytes and then similar to the encryption 
        ///  process here too we will generate Key and IV using the derived bytes and the symmetric key.
        ///  Using MemoryStream and CryptoStream the cipher text is decrypted and written to byte array and
        ///  finally the byte array is converted to Base64String and returned, which is the decrypted original text.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns>string</returns>
        public static string Decrypt(string cipherText)
        {
            string _encryptionKey = System.Configuration.ConfigurationManager.AppSettings["EncryptionKey"].ToString();
            string EncryptionKey = _encryptionKey;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            string clearText = string.Empty;
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    clearText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}