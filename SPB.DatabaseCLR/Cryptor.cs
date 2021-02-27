using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

internal static class Cryptor
{
    //***********************************************************/
    // CALCUL Output Length

    //  CipherText = PlainText + Block - (PlainText MOD Block) 
    //  For AES, the block size is 16 bytes 
    //  n + 16 - (n % 16)
    //  19 char plaintext ==> 32 Bytes encrypted (BYTE ARRAY)

    // Convert BYTE ARRAY to printable string in Base64
    // Base64 encoding uses 4 printable characters for every 3 binary characters
    // Base64 = (Bytes + 2 - ((Bytes + 2) MOD 3)) / 3 * 4
    // 32 Bytes ==> 44-character string

    // Therefore, 19 bytes encrypted using AES results in 32 binary bytes. The 32 bytes represented as a printable string in Base64 is 44 characters. 
    // In summary: Encrypting 19 bytes with AES will always result in a 44-character Base64 string.

    // Text Length  =   Encryp-Base64 Length
    // 128 varchar  =    192 varchar
    //  64 varchar  =    108 varchar
    //  50 varchar  =     88 varchar
    //  32 varchar  =     64 varchar
    //  19 varchar  =     44 varchar
    //  16 varchar  =     44 varchar


    //***********************************************************/



    /// <summary>
    /// This class uses a symmetric key algorithm (Rijndael/AES) to encrypt and 
    /// decrypt data. As long as encryption and decryption routines use the same
    /// parameters to generate the keys, the keys are guaranteed to be the same.
    /// The class uses static functions with duplicate code to make it easier to
    /// demonstrate encryption and decryption logic. In a real-life application, 
    /// this may not be the most efficient way of handling encryption, so - as
    /// soon as you feel comfortable with it - you may want to redesign this class.
    /// </summary>


    /// <summary>
    /// Encrypts specified plaintext using Rijndael symmetric key algorithm
    /// and returns a base64-encoded result.
    /// </summary>
    /// <param name="plainText">
    /// Plaintext value to be encrypted.
    /// </param>
    public static string Encrypt(string PlainText)
    {
        if (PlainText == null)
            return null;

        if (string.IsNullOrEmpty(PlainText))
            return string.Empty;

        byte[] KeyBytes;
        byte[] InitialVectorBytes;
        string passPhrase;
        string Salt;                                /// Salt value used along with passphrase to generate password. Salt can be any string.
        string InitialVector;                       /// For RijndaelManaged class IV must be exactly 16 ASCII characters long.
        string HashAlgorithm = "SHA1";              /// Hash algorithm used to generate password. Allowed values are: "MD5" and "SHA1". SHA1 hashes are a bit slower, but more secure than MD5 hashes.
        int PasswordIterations = 2;                 /// Number of iterations used to generate password. One or two iterations should be enough.
        int KeySize = 256;                          /// Size of encryption key in bits. Allowed values are: 128, 192, and 256. Longer keys are more secure than shorter keys.


        passPhrase = "552PGF7AQaATap2upYCEnY62nzCamPs3";
        Salt = "JaguarSolutions";
        InitialVector = "@4$dGi*7/;{0jHNr";


        // Convert strings into byte arrays.
        // Let us assume that strings only contain ASCII codes.
        // If strings include Unicode characters, use Unicode, UTF7, or UTF8 encoding.
        byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
        InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);

        // First, we must create a password, from which the key will be derived.
        // This password will be generated from the specified passphrase and 
        // salt value. The password will be created using the specified hash 
        // algorithm. Password creation can be done in several iterations.
        PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(passPhrase, SaltValueBytes, HashAlgorithm, PasswordIterations);

        // Use the password to generate pseudo-random bytes for the encryption
        // key. Specify the size of the key in bytes (instead of bits).
        KeyBytes = DerivedPassword.GetBytes(KeySize / 8);

        string cipherText = string.Empty;

        // Convert our plaintext into a byte array. Let us assume that plaintext contains UTF8-encoded characters.
        byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);

        // Create uninitialized Rijndael encryption object.
        RijndaelManaged SymmetricKey = new RijndaelManaged();

        // It is reasonable to set encryption mode to Cipher Block Chaining
        // (CBC). Use default options for other symmetric key parameters.
        SymmetricKey.Mode = CipherMode.CBC;

        byte[] CipherTextBytes = null;

        // Generate encryptor from the existing key bytes and initialization 
        // vector. Key size will be defined based on the number of the key bytes.
        using (ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes))
        {
            // Define memory stream which will be used to hold encrypted data.
            using (MemoryStream MemStream = new MemoryStream())
            {
                // Define cryptographic stream (always use Write mode for encryption).
                using (CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
                {
                    // Start encrypting.
                    CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);

                    // Finish encrypting.
                    CryptoStream.FlushFinalBlock();

                    // Convert our encrypted data from a memory stream into a byte array.
                    CipherTextBytes = MemStream.ToArray();
                }
            }
        }
        SymmetricKey.Clear();

        // Convert encrypted data into a base64-encoded string.
        cipherText = Convert.ToBase64String(CipherTextBytes);

        return cipherText;
    }


    /// <summary>
    /// Decrypts specified ciphertext using Rijndael symmetric key algorithm.
    /// </summary>
    /// <param name="cipherText">
    /// Base64-formatted ciphertext value.
    /// </param>
    public static string Decrypt(string CipherText)
    {
        if (CipherText == null)
            return null;

        if (string.IsNullOrEmpty(CipherText))
            return string.Empty;

        byte[] KeyBytes;
        byte[] InitialVectorBytes;
        string passPhrase;
        string Salt;                                /// Salt value used along with passphrase to generate password. Salt can be any string.
        string InitialVector;                       /// For RijndaelManaged class IV must be exactly 16 ASCII characters long.
        string HashAlgorithm = "SHA1";              /// Hash algorithm used to generate password. Allowed values are: "MD5" and "SHA1". SHA1 hashes are a bit slower, but more secure than MD5 hashes.
        int PasswordIterations = 2;                 /// Number of iterations used to generate password. One or two iterations should be enough.
        int KeySize = 256;                          /// Size of encryption key in bits. Allowed values are: 128, 192, and 256. Longer keys are more secure than shorter keys.


        passPhrase = "552PGF7AQaATap2upYCEnY62nzCamPs3";
        Salt = "JaguarSolutions";
        InitialVector = "@4$dGi*7/;{0jHNr";


        // Convert strings into byte arrays.
        // Let us assume that strings only contain ASCII codes.
        // If strings include Unicode characters, use Unicode, UTF7, or UTF8 encoding.
        byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
        InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);

        // First, we must create a password, from which the key will be derived.
        // This password will be generated from the specified passphrase and 
        // salt value. The password will be created using the specified hash 
        // algorithm. Password creation can be done in several iterations.
        PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(passPhrase, SaltValueBytes, HashAlgorithm, PasswordIterations);

        // Use the password to generate pseudo-random bytes for the encryption
        // key. Specify the size of the key in bytes (instead of bits).
        KeyBytes = DerivedPassword.GetBytes(KeySize / 8);

        string plainText = string.Empty;

        // Convert our ciphertext into a byte array.
        byte[] CipherTextBytes = Convert.FromBase64String(CipherText);

        // Create uninitialized Rijndael encryption object.
        RijndaelManaged SymmetricKey = new RijndaelManaged();

        // It is reasonable to set encryption mode to Cipher Block Chaining
        // (CBC). Use default options for other symmetric key parameters.
        SymmetricKey.Mode = CipherMode.CBC;

        // Since at this point we don't know what the size of decrypted data
        // will be, allocate the buffer long enough to hold ciphertext;
        // plaintext is never longer than ciphertext
        byte[] PlainTextBytes = new byte[CipherTextBytes.Length];
        int ByteCount = 0;

        // Generate decryptor from the existing key bytes and initialization 
        // vector. Key size will be defined based on the number of the key bytes.
        using (ICryptoTransform Decryptor = SymmetricKey.CreateDecryptor(KeyBytes, InitialVectorBytes))
        {
            // Define memory stream which will be used to hold encrypted data.
            using (MemoryStream MemStream = new MemoryStream(CipherTextBytes))
            {
                // Define cryptographic stream (always use Read mode for encryption).
                using (CryptoStream CryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read))
                {
                    // Start decrypting.
                    ByteCount = CryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length);
                }
            }
        }
        SymmetricKey.Clear();

        // Convert decrypted data into a string. 
        // Let us assume that the original plaintext string was UTF8-encoded.
        plainText = Encoding.UTF8.GetString(PlainTextBytes, 0, ByteCount);

        return plainText;
    }
}
