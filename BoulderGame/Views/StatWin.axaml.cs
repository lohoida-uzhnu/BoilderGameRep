using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace BoulderGame
{
    public partial class StatWin : Window
    {
        public StatWin()
        {
            InitializeComponent();
        }
        public void SortByScore_Click(object? sender, RoutedEventArgs e)
        {
            // Логика сортировки по очкам
        }
        public void SortByName_Click(object? sender, RoutedEventArgs e)
        {
            // Логика сортировки по имени
        }
        public void BackToMenu_Click(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
