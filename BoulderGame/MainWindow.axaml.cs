using Avalonia.Interactivity;
using Avalonia.Controls;

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
            gameW.Closed += (s, args) => this.Show();
            this.Hide();
        }
        public void StatButton_Click(object? sender, RoutedEventArgs e)
        {
            var statW = new StatWin();
            this.Hide();
            statW.Closed += (s, args) => this.Show();
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
            this.Close();
        }
    }
}