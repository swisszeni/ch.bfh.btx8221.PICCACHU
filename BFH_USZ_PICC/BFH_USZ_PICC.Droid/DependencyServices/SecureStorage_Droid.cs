using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using BFH_USZ_PICC.Interfaces;
using Java.Security;
using Android.Security;
using Javax.Security.Auth.X500;
using Java.Math;
using Java.Util;
using Android.Security.Keystore;
using Javax.Crypto;
using Plugin.Settings;
using Java.IO;
using System.IO;
using Android.Util;
using Javax.Crypto.Spec;

[assembly: Dependency(typeof(BFH_USZ_PICC.Droid.DependencyServices.SecureStorage_Droid))]

/// <summary>
/// Since Android is lacking a pendant to iOSs KeyChain, we have to implement a different solution
/// This implementation generates a random key that is stored in the KeyChain of the os
/// Since prior to API23 only RSA Keys could be stored, we different techniques depending on API level
/// Implementation is based mainly on this writeup: https://medium.com/@ericfu/securely-storing-secrets-in-an-android-application-501f030ae5a3#.2st0c6rh9
/// </summary>
namespace BFH_USZ_PICC.Droid.DependencyServices
{
    public class SecureStorage_Droid : ISecureStorage
    {
        private static readonly string _droidKeyStore = "AndroidKeyStore";
        private static readonly string _secureStoredKeyAlias = "ch.bfh.i4m1.picc.MainKey";
        private static readonly string _settingStoredKeyAlias = "ch.bfh.i4m1.picc.MainKeyEncrypted";
        private static readonly string _AESMode = "AES/GCM/NoPadding";
        private static readonly string _AESMode_Depr = "AES/ECB/PKCS7Padding";
        private static readonly string _RSAMode = "RSA/ECB/PKCS1Padding";
        private static readonly byte[] _fixedIV = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11 };

        private static readonly string _keyPrefix = "EncryptedKey:";

        private readonly KeyStore _keyStore;

        public SecureStorage_Droid()
        {
            _keyStore = KeyStore.GetInstance(_droidKeyStore);
            _keyStore.Load(null);

            // Check if the RSA Key for encryptiong the stored credentials already exists
            // Typically, this needs to be created when the database and its corresponding keys is generated on first App launch
            if (!_keyStore.ContainsAlias(_secureStoredKeyAlias))
            {
                // We have to check the API level to avoid using deprecated methods when not needed
                if ((int)Build.VERSION.SdkInt > 22)
                {
                    GenerateAESKey_New();
                }
                else
                {
                    GenerateRSAKey();
                    GenerateAESKey_Depr();
                }
            }
        }

        #region ISecureStorage Members

        /// <summary>
        /// Checks if the storage contains a key.
        /// </summary>
        /// <param name="key">The key to search.</param>
        /// <returns>True if the storage has the key, otherwise false.</returns>
        public bool Contains(string key)
        {
            return CrossSettings.Current.Contains(_keyPrefix + key);
        }

        /// <summary>
        /// Deletes data.
        /// </summary>
        /// <param name="key">Key for the data to be deleted.</param>
        public void Delete(string key)
        {
            CrossSettings.Current.Remove(_keyPrefix + key);
        }

        /// <summary>
        /// Deletes all saved data.
        /// If there is a master key used for storage, it is deleted too
        /// </summary>
        public void WipeStorage()
        {
            _keyStore.DeleteEntry(_secureStoredKeyAlias);
            CrossSettings.Current.Remove(_settingStoredKeyAlias);
        }

        /// <summary>
        /// Retrieves stored data.
        /// </summary>
        /// <param name="key">Key for the data.</param>
        /// <returns>Byte array of stored data.</returns>
        public byte[] Retrieve(string key)
        {
            byte[] decryptedData;
            string encryptedData = CrossSettings.Current.GetValueOrDefault<string>(key);
            if ((int)Build.VERSION.SdkInt > 22)
            {
                decryptedData = AESDecrypt_New(encryptedData);
            } else
            {
                decryptedData = AESDecrypt_Depr(encryptedData);
            }

            return decryptedData;
        }

        /// <summary>
        /// Stores data.
        /// </summary>
        /// <param name="key">Key for the data.</param>
        /// <param name="dataBytes">Data bytes to store.</param>
        public void Store(string key, byte[] dataBytes)
        {
            string encryptedData;
            if ((int)Build.VERSION.SdkInt > 22)
            {
                encryptedData = AESEncrypt_New(dataBytes);
            } else
            {
                encryptedData = AESEncrypt_Depr(dataBytes);
            }

            CrossSettings.Current.AddOrUpdateValue(key, encryptedData);
        }

        #endregion

        #region private encrpytion methods

        #region new encryption

        private void GenerateAESKey_New()
        {
            // Generate a key pair for encryption
            KeyGenerator keyGenerator = KeyGenerator.GetInstance(KeyProperties.KeyAlgorithmAes, _droidKeyStore);
            keyGenerator.Init(
                    new KeyGenParameterSpec.Builder(_secureStoredKeyAlias,
                            KeyStorePurpose.Encrypt | KeyStorePurpose.Decrypt)
                            .SetBlockModes(KeyProperties.BlockModeGcm)
                            .SetEncryptionPaddings(KeyProperties.EncryptionPaddingNone)
                            .SetRandomizedEncryptionRequired(false)
                            .Build());
            keyGenerator.GenerateKey();
        }

        private string AESEncrypt_New(byte[] decrypted)
        {
            Cipher c = Cipher.GetInstance(_AESMode);
            KeyStore.IEntry storeEntry = _keyStore.GetEntry(_secureStoredKeyAlias, null);
            IKey key = ((KeyStore.SecretKeyEntry)storeEntry).SecretKey;
            GCMParameterSpec param = new GCMParameterSpec(128, _fixedIV);
            c.Init(CipherMode.EncryptMode, key, param);
            byte[] encodedBytes = c.DoFinal(decrypted);
            return Base64.EncodeToString(encodedBytes, Base64Flags.Default);
        }

        private byte[] AESDecrypt_New(string encrypted)
        {
            Cipher c = Cipher.GetInstance(_AESMode);
            IKey key = ((KeyStore.SecretKeyEntry)_keyStore.GetEntry(_secureStoredKeyAlias, null)).SecretKey;
            GCMParameterSpec param = new GCMParameterSpec(128, _fixedIV);
            c.Init(CipherMode.DecryptMode, key, param);
            return c.DoFinal(Base64.Decode(encrypted, Base64Flags.Default));
        }

        #endregion

        #region deprecated encryption

        private void GenerateRSAKey()
        {
            // Generate a key pair for encryption
            Calendar start = Calendar.GetInstance(Locale.Default);
            Calendar end = Calendar.GetInstance(Locale.Default);
#pragma warning disable CS0618 // Type or member is obsolete
            end.Add(Calendar.Year, 30);

            KeyPairGeneratorSpec spec = new KeyPairGeneratorSpec.Builder(Android.App.Application.Context)
#pragma warning restore CS0618 // Type or member is obsolete
                    .SetAlias(_secureStoredKeyAlias)
                    .SetSubject(new X500Principal("CN=" + _secureStoredKeyAlias))
                    .SetSerialNumber(BigInteger.Ten)
                    .SetStartDate(start.Time)
                    .SetEndDate(end.Time)
                    .Build();
            KeyPairGenerator kpg = KeyPairGenerator.GetInstance(KeyProperties.KeyAlgorithmRsa, _droidKeyStore);
            kpg.Initialize(spec);
            kpg.GenerateKeyPair();
        }

        private byte[] RSAEncrypt(byte[] secret)
        {
            KeyStore.PrivateKeyEntry privateKeyEntry = (KeyStore.PrivateKeyEntry)_keyStore.GetEntry(_secureStoredKeyAlias, null);
            // Encrypt the text
            Cipher inputCipher = Cipher.GetInstance(_RSAMode, "AndroidOpenSSL");
            inputCipher.Init(CipherMode.EncryptMode, privateKeyEntry.Certificate.PublicKey);

            MemoryStream outputStream = new MemoryStream();
            CipherOutputStream cipherOutputStream = new CipherOutputStream(outputStream, inputCipher);
            cipherOutputStream.Write(secret);
            cipherOutputStream.Close();

            return outputStream.ToArray();
        }

        private byte[] RSADecrypt(byte[] encrypted)
        {
            KeyStore.PrivateKeyEntry privateKeyEntry = (KeyStore.PrivateKeyEntry)_keyStore.GetEntry(_secureStoredKeyAlias, null);

            Cipher output = Cipher.GetInstance(_RSAMode, "AndroidOpenSSL");
            IKey pk = privateKeyEntry.PrivateKey;
            output.Init(CipherMode.DecryptMode, pk );

            CipherInputStream cipherInputStream = new CipherInputStream(new MemoryStream(encrypted), output);
            List<byte> values = new List<byte>();

            int nextByte;
            while ((nextByte = cipherInputStream.Read()) != -1)
            {
                values.Add((byte)nextByte);
            }

            return values.ToArray();
        }

        private void GenerateAESKey_Depr()
        {
            if(!CrossSettings.Current.Contains(_settingStoredKeyAlias))
            {
                // AES Key does not yet exist, let's create one
                byte[] key = new byte[16];
                SecureRandom secureRandom = new SecureRandom();
                secureRandom.NextBytes(key);

                byte[] encryptedKey = RSAEncrypt(key);
                string enryptedKeyB64 = Base64.EncodeToString(encryptedKey, Base64Flags.Default);

                CrossSettings.Current.AddOrUpdateValue(_settingStoredKeyAlias, enryptedKeyB64);
            }
        }

        private IKey RetrieveAESKey_Depr()
        {
            string enryptedKeyB64 = CrossSettings.Current.GetValueOrDefault<string>(_settingStoredKeyAlias);

            // need to check null, omitted here
            if(enryptedKeyB64 != null)
            {
                byte[] encryptedKey = Base64.Decode(enryptedKeyB64, Base64Flags.Default);
                byte[] key = RSADecrypt(encryptedKey);
                return new SecretKeySpec(key, "AES");
            } else
            {
                throw new Exception("Failed to retrieve existing MainEncryptionKey for Database");
            }
        }

        private string AESEncrypt_Depr(byte[] decrypted)
        {
            Cipher c = Cipher.GetInstance(_AESMode_Depr, "BC");
            IKey key = RetrieveAESKey_Depr();
            c.Init(CipherMode.EncryptMode, RetrieveAESKey_Depr());
            byte[] encodedBytes = c.DoFinal(decrypted);
            return Base64.EncodeToString(encodedBytes, Base64Flags.Default);
        }

        private byte[] AESDecrypt_Depr(string encrypted)
        {
            Cipher c = Cipher.GetInstance(_AESMode_Depr, "BC");
            c.Init(CipherMode.DecryptMode, RetrieveAESKey_Depr());
            return c.DoFinal(Base64.Decode(encrypted, Base64Flags.Default));
        }

        #endregion

        #endregion
    }
}