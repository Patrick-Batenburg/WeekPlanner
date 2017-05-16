﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SamenSterk.Providers
{
    public class EncryptionProvider
    {
        /// <summary> 
        /// Encrypts a string.
        /// </summary> 
        /// <param name="value">String to encrypt.</param> 
        /// <returns>Encrypted string.</returns> 
        public static string Encrypt(string value)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(value + Properties.Settings.Default.Salt);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        } 
    }
}