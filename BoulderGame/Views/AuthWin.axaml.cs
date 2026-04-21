using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace BoulderGame;

public partial class AuthWindow : Window
{
    public AuthWindow()
    {
        InitializeComponent();
        Navigate(new LoginPage());
    }
    public void Navigate(UserControl page)
    {
        MainContentArea.Content = page;
    }
}