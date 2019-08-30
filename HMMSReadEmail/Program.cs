using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HMMSReadEmail
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new HmmsService()
            };
            ServiceBase.Run(ServicesToRun);
        }
        // ******************************************************************************************************************************
        // ** Store this code here because if we have to recreate the Entity Framework this code would be lost
        // ** Therefore we will store it here and copy and paste back into the file \HMMSReadEmail\HMMSReadEmail\HMMSModel.Context.cs
        // ******************************************************************************************************************************

        //public HMMSEntitiesDB()
        //    : base("name=HMMSEntitiesDB")
        //{
        //    string conString = Database.Connection.ConnectionString;
        //    string[] conArray = conString.Split(';');
        //    string conPassword = conArray[4].Substring(conArray[4].IndexOf("=") + 1);
        //    byte[] Key = Encoding.ASCII.GetBytes("AECOM_HMMC_HMMS1");
        //    byte[] IV = Encoding.ASCII.GetBytes("AECOM_HMMC_HMMS1");
        //    string encrypted = Encrypt("Pencil$1492", Key, IV);
        //    string DecodeAndDecrypt = Decrypt(Convert.FromBase64String(conPassword), Key, IV);
        //    Database.Connection.ConnectionString = conString.Replace(conPassword, DecodeAndDecrypt);
        //}
        //static string Encrypt(string plainText, byte[] Key, byte[] IV)
        //{
        //    string encrypted;
        //    // Create a new AesManaged.    
        //    using (AesManaged aes = new AesManaged())
        //    {
        //        // Create encryptor    
        //        ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
        //        // Create MemoryStream    
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            // Create crypto stream using the CryptoStream class. This class is the key to encryption    
        //            // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
        //            // to encrypt    
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        //            {
        //                // Create StreamWriter and write data to a stream    
        //                using (StreamWriter sw = new StreamWriter(cs))
        //                    sw.Write(plainText);
        //                encrypted = Convert.ToBase64String(ms.ToArray());
        //            }
        //        }
        //    }
        //    // Return encrypted data    
        //    return encrypted;
        //}
        //static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
        //{
        //    string plaintext = null;
        //    // Create AesManaged    
        //    using (AesManaged aes = new AesManaged())
        //    {
        //        // Create a decryptor    
        //        ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
        //        // Create the streams used for decryption.    
        //        using (MemoryStream ms = new MemoryStream(cipherText))
        //        {
        //            // Create crypto stream    
        //            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
        //            {
        //                // Read crypto stream    
        //                using (StreamReader reader = new StreamReader(cs))
        //                    plaintext = reader.ReadToEnd();
        //            }
        //        }
        //    }
        //    return plaintext;
        //}
    }
}
