using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Text.Json;

namespace BoulderGame;

public partial class SettingWin : Window
{
    public SettingWin()
    {
        InitializeComponent();

        ThemeSwitch.IsChecked = Application.Current!.RequestedThemeVariant == ThemeVariant.Dark;
    }

    public void ThemeSwitch_IsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        if (ThemeSwitch !=null)
        {
            bool isDark = ThemeSwitch.IsChecked == true;
            Application.Current!.RequestedThemeVariant = isDark ? ThemeVariant.Dark : ThemeVariant.Light;

            string currentLang = GetCurrentLanguage();
            App.SaveSettings(currentLang, isDark);
        }
    }
    private void LangComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (sender is Avalonia.Controls.ComboBox comboBox &&
            comboBox.SelectedItem is ComboBoxItem selectedItem)
        {
            string? langCode = selectedItem.Tag?.ToString();

            if (!string.IsNullOrEmpty(langCode))
            {
                App.SetLanguage(langCode);

                bool isDark = Application.Current!.RequestedThemeVariant == ThemeVariant.Dark;
                App.SaveSettings(langCode, isDark);
            }
        }
    }
    private string GetCurrentLanguage()
    {
        return (LangComboBox.SelectedItem as ComboBoxItem)?.Tag?.ToString() ?? "en";
    }
    public void BackToMenu_Click(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}