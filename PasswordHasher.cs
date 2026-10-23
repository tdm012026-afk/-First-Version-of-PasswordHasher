using System;
using System.Security.Cryptography;

public class PasswordHasher
{
    public string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt, 
            100_000,
            HashAlgorithmName.SHA256,
            32
        );

        string saltString = Convert.ToBase64String(salt);
        string hashString = Convert.ToBase64String(hash);

        return $"{saltString}{hashString}";    // returns two elemts as a one text
    }
    public bool VerifyPassword(string password, string storedPassword)
    {
        string[] parts = storedPassword.Split(':');

        byte[] salt = Convert.FromBase64String(parts[0]);
        byte[] storedHash = Convert.FromBase64String(parts[1]);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            100_000,
            HashAlgorithmName.SHA256,
            32
        );
        return CryptographicOperations.FixedTimeEquals(hash, storedHash);
    }
}