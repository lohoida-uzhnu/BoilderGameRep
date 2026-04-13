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
        public void StartGame_Click(object? sender, RoutedEventArgs e)
        {
            var gameW = new GameScreen();
            gameW.Show();
            this.Close();
        }
        public void ExitButton_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void StatButton_Click(object? sender, RoutedEventArgs e)
        {
            var statW = new StatWin();
            statW.Show();
            this.Close();
        }
    }
}