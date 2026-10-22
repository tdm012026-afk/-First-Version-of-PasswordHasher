using System;

PasswordHasher hasher = new PasswordHasher();

System.Console.Write("Enter password : ");
string? password = Console.ReadLine();

if (password != null)
{
    string hashedPassword = hasher.HashPasswrord(password);

    System.Console.WriteLine($"Hashed Password : {hashedPassword}");
}