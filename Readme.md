
** Basic Password Hasher V1 **

** About **

This project is a simple C# console application. created to learn and show how password hash, salt and verification work.
This is just a learning project, can be used to generate a hash and salt.
Used Technologies : C# , .NET 10 , PBKDF2 , SHA-256

** Features

- Hashes passwords using PBKDF2 with SHA-256.
- Generates a random salt for each password.
- Stores the salt and hash together in Base64 format.
- Verifies passwords by comparing the calculated hash with the stored hash.
- Uses a fixed-time comparison to reduce timing-based information leaks.

**  How it flows, how it works

1. The user enters a password.
2. The application generates a random salt.
3. PBKDF2 derives a hash from the password and salt.
4. The salt and hash are stored together as a string.
5. The user enters the password again.
6. The application calculates a new hash and compares it with the stored hash.



