using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
using System.Security.Cryptography.X509Certificates;

namespace BoulderGame;

public partial class SettingWin : Window
{
    public SettingWin()
    {
        InitializeComponent();
    }

    public void ThemeSwitch_IsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        if (ThemeSwitch.IsChecked == true)
        {
            Application.Current!.RequestedThemeVariant = ThemeVariant.Dark;
        }
        else
        {
            Application.Current!.RequestedThemeVariant = ThemeVariant.Light;
        }
    }
    public void BackToMenu_Click(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}