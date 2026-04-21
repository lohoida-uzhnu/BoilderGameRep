using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using BoulderGame.Model;

namespace BoulderGame
{
    public partial class StatWin : Window
    {
        private ObservableCollection<PlayerRecord> _scoresCollection;

        private bool _isAscending = false;
        private bool _isNameAscending = false;

        public StatWin()
        {
            InitializeComponent();

            var rawData = ScoreManager.LoadScores();
            _scoresCollection = new ObservableCollection<PlayerRecord>(rawData);

            ScoreList.ItemsSource = _scoresCollection;
        }

        private void SortScore_Click(object? sender, RoutedEventArgs e)
        {
            if (_scoresCollection == null || !_scoresCollection.Any()) return;

            List<PlayerRecord> sorted;

            if (_isAscending)
            {
                sorted = _scoresCollection.OrderBy(x => x.Score).ToList();
                _isAscending = false;
            }
            else
            {
                sorted = _scoresCollection.OrderByDescending(x => x.Score).ToList();
                _isAscending = true;
            }

            ApplySorting(sorted);
        }

        public void SortByName_Click(object? sender, RoutedEventArgs e)
        {
            if (_scoresCollection == null || !_scoresCollection.Any()) return;

            List<PlayerRecord> sorted;

            if (_isNameAscending)
            {
                sorted = _scoresCollection.OrderBy(x => x.Username).ToList();
                _isNameAscending = false;
            }
            else
            {
                sorted = _scoresCollection.OrderByDescending(x => x.Username).ToList();
                _isNameAscending = true;
            }

            ApplySorting(sorted);
        }

        private void ApplySorting(List<PlayerRecord> sortedList)
        {
            _scoresCollection.Clear();
            foreach (var item in sortedList)
            {
                _scoresCollection.Add(item);
            }

            for (int i = 0; i < _scoresCollection.Count; i++)
            {
                sortedList[i].Id = i + 1;
            }
        }

        public void BackToMenu_Click(object? sender, RoutedEventArgs e)
        {
            var mainW = new MainWindow();
            mainW.Show();
            this.Close();
        }
    }
}