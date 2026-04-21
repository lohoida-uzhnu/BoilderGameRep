using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia;
using System;

namespace BoulderGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void StartGameBut_Click(object? sender, RoutedEventArgs e)
        {
            var gameW = new GameScreen();
            gameW.Show();
            this.Hide();
        }
        public void StatButton_Click(object? sender, RoutedEventArgs e)
        {
            var statW = new StatWin();
            this.Hide();
            statW.Show();
        }
        public void SettingBut_Click(object? sender, RoutedEventArgs e)
        {
            var settingW = new SettingWin();
            this.Hide();
            settingW.Closed += (s, args) => this.Show();
            settingW.Show();
        }
        public void ExitButton_Click(object? sender, RoutedEventArgs e)
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown();
            }
        }
    }
}