using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using BoulderGame.Model;

namespace BoulderGame;

public partial class LoginPage : UserControl
{
    public LoginPage()
    {
        InitializeComponent();
        this.DataContext = new LoginViewModel();
    }

    public void SignIn_Click(object? sender, RoutedEventArgs e)
    {
        var viewModel = (LoginViewModel)this.DataContext;

        string username = viewModel.Login;
        string password = viewModel.Password;
        string filePath = "users.json";

        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            var users = JsonSerializer.Deserialize<List<User>>(jsonString);

            var user = users?.FirstOrDefault(u => u.Login == username && u.Password == password);

            if (user != null)
            {
                Session.CurrentUsername = user.Login;

                var gameWin = new MainWindow();
                gameWin.Show();
                if (this.VisualRoot is Window w) w.Close();

                var currentWindow = TopLevel.GetTopLevel(this) as Window;
                currentWindow?.Close();
            }
            else
            {
                ShowError("Incorrect login or password!");
            }
        }
    }
    public void ShowPass_Changed(object? sender, RoutedEventArgs e)
    {
        var CheckBox = sender as CheckBox;

        if (CheckBox?.IsChecked == true)
        {
           PassBox.PasswordChar = '\0';
        }
        else
        {
            PassBox.PasswordChar = '*';
        }
    }
    private void GoToSignUp_Click(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        var window = TopLevel.GetTopLevel(this) as AuthWindow;

        if (window != null)
        {
            window.Navigate(new RegisterPage());
        }
    }

    private void ShowError(string message)
    {
        ErrorText.Text = message;
        ErrorText.IsVisible = true;

        System.Diagnostics.Debug.WriteLine(message);
    }
}