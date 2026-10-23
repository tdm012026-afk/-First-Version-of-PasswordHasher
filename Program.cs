using System;

PasswordHasher hasher = new PasswordHasher();

System.Console.Write("Enter password : ");
string? password = Console.ReadLine();

if (password != null)
{
    string storedPassword = hasher.HashPassword(password);

    System.Console.WriteLine("Successfully hasherd password.");

    Console.Write("Please Verify your password again :");
    string? enteredPassword = Console.ReadLine();

    if (enteredPassword != null)
    {
        bool isPasswordValid = hasher.VerifyPassword(
            enteredPassword,
            storedPassword
        );

        Console.WriteLine($"Correct Password : {isPasswordValid}");
    }
}