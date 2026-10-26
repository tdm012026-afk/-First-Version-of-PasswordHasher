using System;
using System.Security.Cryptography;

public class PasswordHasher
{
    public string HashPassword(string password)
    {
        // generate random salt for password
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        // generate a password hash using PBKDF2 with SHA-256
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt, 
            100_000,
            HashAlgorithmName.SHA256,
            32
        );
        // converting salt and hash to Base64 string for storage
        
        string saltString = Convert.ToBase64String(salt);
        string hashString = Convert.ToBase64String(hash);
        
        // save- store both values in one string
        return $"{saltString}:{hashString}";    // separated by a colon
    }
    public bool VerifyPassword(string password, string storedPassword)
    {   
        // reject empty password data 
        if (string.IsNullOrEmpty(storedPassword))
        {
            return false;
        }
        // split saved-stored data into salt and hash
        string[] parts = storedPassword.Split(':');

        // stored-saved data must contain two parts
        if(parts.Length != 2)
        {
            return false;
        }

        // convsert stored-saved Base64 string back to byte arrays 
        byte[] salt = Convert.FromBase64String(parts[0]);
        byte[] storedHash = Convert.FromBase64String(parts[1]);

        // entered hash is hashed using original salt and settings
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            100_000,
            HashAlgorithmName.SHA256,
            32
        );

        // compare hashes using comparison
        return CryptographicOperations.FixedTimeEquals(hash, storedHash);
    }
}