using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace BoulderGame;

public partial class RegisterPage : UserControl
{
    public RegisterPage()
    {
        InitializeComponent();

        this.DataContext = new RegisterViewModel();
    }

    private void SignUp_Click(object? sender, RoutedEventArgs e)
    {
        var viewModel = (RegisterViewModel)this.DataContext;

        string username = viewModel.Login;
        string password = viewModel.Password;
        string confirmPassword = viewModel.ConfirmPassword;

        if (string.IsNullOrEmpty(password) ||
            password.Length < 8 ||
            !password.Any(char.IsUpper) ||
            !password.Any(char.IsDigit))
        {
            ErrorText.IsVisible = true;
            ErrorText.Text = "Password must be at least 8 characters long and contain at least one uppercase letter and one digit!";
            return;
        }

        if (password != confirmPassword)
        {
            ErrorText.IsVisible = true;
            ErrorText.Text = "Passwords do not match!";
            return;
        }

        string filePath = "users.json";
        List<User> users = new List<User>();

        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            users = JsonSerializer.Deserialize<List<User>>(jsonString) ?? new List<User>();
        }

        bool userExists = users.Any(u => u.Login == username);
        if (userExists)
        {
            ErrorText.IsVisible = true;
            ErrorText.Text = "A user with this login already exists!";

            return;
        }

        var newUser = new User { Login = username, Password = password };
        users.Add(newUser);

        string updatedJson = JsonSerializer.Serialize(users);
        File.WriteAllText(filePath, updatedJson);

        if (this.VisualRoot is AuthWindow authWin)
        {
            authWin.Navigate(new LoginPage());
        }
    }

    private void GoToSignIn_Click(object? sender, PointerPressedEventArgs e)
    {
        var window = TopLevel.GetTopLevel(this) as AuthWindow;

        if (window != null) 
        {
            window.Navigate(new LoginPage());
        }
    }
}