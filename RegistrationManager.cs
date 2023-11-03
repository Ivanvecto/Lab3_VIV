// RegistrationManager.cs
using System;

public class RegistrationManager
{
    private readonly IUserDatabase _userDatabase;

    public RegistrationManager(IUserDatabase userDatabase)
    {
        _userDatabase = userDatabase;
    }

    public bool Register(string username, string password, string confirmPassword)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
        {
            throw new ArgumentException("Username, password, and confirmation password cannot be empty.");
        }

        if (password != confirmPassword)
        {
            return false; // Passwords do not match
        }

        if (_userDatabase.UserExists(username))
        {
            return false; // User with the same username already exists
        }

        _userDatabase.AddUser(username, password);
        return true;
    }
}
