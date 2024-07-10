using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BaseAPI.Services
{
    public  class TextFunctions
    {
        protected byte[] IV = Encoding.ASCII.GetBytes("Devjoker7.37hAES");
        protected byte[] Clave = Encoding.ASCII.GetBytes("LaMananaMeSonrieAlDespertarMelodiaDeLasAvesAlCantarMeHaceSuspirar2111");


        public string Encriptar(string? texto)
        {
            try
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] inputBytes = (new UnicodeEncoding()).GetBytes(texto);
                byte[] hash = sha1.ComputeHash(inputBytes);

                return Convert.ToBase64String(hash);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string Encripta(string Cadena)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(Cadena);
            byte[] encripted;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes.Length))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(Clave, IV), CryptoStreamMode.Write))
                {
                    objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    objCryptoStream.FlushFinalBlock();
                    objCryptoStream.Close();
                }
                encripted = ms.ToArray();
            }
            return Convert.ToBase64String(encripted);
        }
        public string Desencripta(string Cadena)
        {
            byte[] inputBytes = Convert.FromBase64String(Cadena);
            byte[] resultBytes = new byte[inputBytes.Length];
            string textoLimpio = String.Empty;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(Clave, IV), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        textoLimpio = sr.ReadToEnd();
                    }
                }
            }
            return textoLimpio;
        }

    }
}
