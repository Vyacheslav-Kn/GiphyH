using AutoMapper;
using GiphyH.BLL.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GiphyH.BLL.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly IConfiguration _configuration;

        public CryptoService(IConfiguration config)
        {
            _configuration = config;
        }

        public string EncryptId(int id)
        {
            byte[] idInBytes = BitConverter.GetBytes(id);
            byte[] cypheredId;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_configuration["EncryptionKey"]);
                aes.IV = new byte[16];

                ICryptoTransform encryptor = aes.CreateEncryptor();

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(idInBytes, 0, idInBytes.Length);
                    }

                    cypheredId = memoryStream.ToArray();
                }
            }

            return WebEncoders.Base64UrlEncode(cypheredId);
        }

        public int DecryptId(string encodedId)
        {
            byte[] idInBytes;
            byte[] cypheredId = WebEncoders.Base64UrlDecode(encodedId);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_configuration["EncryptionKey"]);
                aes.IV = new byte[16];

                ICryptoTransform decryptor = aes.CreateDecryptor();

                using (MemoryStream memoryStream = new MemoryStream(cypheredId))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(cypheredId, 0, cypheredId.Length);
                    }

                    idInBytes = memoryStream.ToArray();
                }
            }

            return BitConverter.ToInt32(idInBytes);
        }

        public string CreatePasswordHash(string password)
        {
            byte[] passwordInBytes = Encoding.UTF8.GetBytes(password);
            byte[] globalSaltInBytes = Encoding.UTF8.GetBytes(_configuration["GlobalSalt"]);

            var sha = new SHA512CryptoServiceProvider();
            var hashOfPassword = sha.ComputeHash(passwordInBytes);

            var addition = hashOfPassword.Concat(globalSaltInBytes).ToArray();
            var hashOfPasswordAndSalt = sha.ComputeHash(addition);

            return BitConverter.ToString(hashOfPasswordAndSalt);
        }
    }
}
