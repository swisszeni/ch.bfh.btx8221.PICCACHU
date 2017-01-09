using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Security.Cryptography.DataProtection;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(BFH_USZ_PICC.UWP.DependencyServices.SecureStorage_UWP))]

namespace BFH_USZ_PICC.UWP.DependencyServices
{
    /// <summary>
    /// Implements <see cref="ISecureStorage"/> for UWP using <see cref="PasswordVault"/>
    /// </summary>
    public class SecureStorage_UWP : ISecureStorage
    {
        private static readonly string _resourceIdentifier = "ch.bfh.i4m1.picc";

        #region ISecureStorage Members

        /// <summary>
        /// Checks if the storage contains a key.
        /// </summary>
        /// <param name="key">The key to search.</param>
        /// <returns>True if the storage has the key, otherwise false.</returns>
        public bool Contains(string key)
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            return vault.Retrieve(_resourceIdentifier, key) != null;
        }

        /// <summary>
        /// Deletes data.
        /// </summary>
        /// <param name="key">Key for the data to be deleted.</param>
        public void Delete(string key)
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            var credentials = vault.Retrieve(_resourceIdentifier, key);
            if (credentials == null)
            {
                // invalid key?
                throw new ArgumentException();
            }

            vault.Remove(credentials);
        }

        /// <summary>
        /// Deletes all saved data.
        /// If there is a master key used for storage, it is deleted too
        /// </summary>
        public void WipeStorage()
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            var allCredentials = vault.FindAllByResource(_resourceIdentifier);
            foreach (var credential in allCredentials)
            {
                vault.Remove(credential);
            }
        }

        /// <summary>
        /// Retrieves stored data.
        /// </summary>
        /// <param name="key">Key for the data.</param>
        /// <returns>Byte array of stored data.</returns>
        public byte[] Retrieve(string key)
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            var credentials = vault.Retrieve(_resourceIdentifier, key);
            if(credentials == null)
            {
                // invalid key?
                throw new ArgumentException();
            }

            return Convert.FromBase64String(credentials.Password);
        }

        /// <summary>
        /// Stores data.
        /// </summary>
        /// <param name="key">Key for the data.</param>
        /// <param name="dataBytes">Data bytes to store.</param>
        public void Store(string key, byte[] dataBytes)
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            // Base64 encode the data bytes
            var encodedValue = Convert.ToBase64String(dataBytes);
            vault.Add(new Windows.Security.Credentials.PasswordCredential(_resourceIdentifier, key, encodedValue));
        }

        #endregion

    }
}
