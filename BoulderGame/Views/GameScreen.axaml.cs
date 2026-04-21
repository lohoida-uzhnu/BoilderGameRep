using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using BoulderGame.Model;

namespace BoulderGame
{
    public partial class GameScreen : Window
    {
        private Player player;
        private List<Boulder> boulders;
        private DispatcherTimer gameTimer;
        private Random random = new Random();

        private bool isGameOver = false;
        private int score = 0;
        private int frameCount = 0;

        private double baseBoulderSpeed = 4.0;
        private int spawnInterval = 5;

        private bool moveLeft = false;
        private bool moveRight = false;

        private const double GameWidth = 1000;
        private const double GameHeight = 800;

        private const double GrassHeight = 100;
        private Rect grassBounds;

        public GameScreen()
        {
            InitializeComponent();
            grassBounds = new Rect(0, GameHeight - GrassHeight, GameWidth, GrassHeight);
            StartGame();
        }

        private void StartGame()
        {
            player = new Player
            {
                Width = 40,
                Height = 40,
                X = GameWidth / 2 - 20,
                Y = GameHeight - GrassHeight - 40
            };

            boulders = new List<Boulder>();
            score = 0;
            frameCount = 0;
            isGameOver = false;

            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(16);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
        }

        private void GameLoop(object? sender, EventArgs e)
        {
            if (isGameOver) return;

            frameCount++;

            UpdatePlayer();
            SpawnBoulders();
            UpdateBoulders(); 
            CheckCollisions();

            UpdateUI(); 
        }

        private void UpdatePlayer()
        {
            if (moveLeft && player.X > 0)
                player.X -= player.Speed;

            if (moveRight && player.X + player.Width < GameWidth)
                player.X += player.Speed;
        }

        private void SpawnBoulders()
        {
            if (frameCount % spawnInterval == 0)
            {
                Boulder newBoulder = new Boulder
                {
                    Width = 30,
                    Height = 30,
                    X = random.Next(0, (int)(GameWidth - 30)),
                    Y = -30,
                    Speed = baseBoulderSpeed + (random.NextDouble() * 2)
                };
                boulders.Add(newBoulder);
            }
        }

        private void UpdateBoulders()
        {
            for (int i = boulders.Count - 1; i >= 0; i--)
            {
                boulders[i].Y += boulders[i].Speed;

                if (boulders[i].Bounds.Intersects(grassBounds))
                {
                    boulders.RemoveAt(i);
                    score++;
                }
            }
        }

        private void CheckCollisions()
        {
            foreach (var boulder in boulders)
            {
                if (player.Bounds.Intersects(boulder.Bounds))
                {
                    GameOver();
                    break;
                }
            }
        }

        private void GameOver()
        {
            isGameOver = true;
            gameTimer.Stop();
            StartGame();
        }

        private void UpdateUI()
        {
            for (int i = GameCanvas.Children.Count - 1; i >= 0; i--)
            {
                var child = GameCanvas.Children[i];
                if (child is Avalonia.Controls.Shapes.Rectangle rect && rect.Name != "GrassLayer")
                {
                    GameCanvas.Children.RemoveAt(i);
                }
            }

            ScoreText.Text = $"Score: {score}";

            var playerShape = new Avalonia.Controls.Shapes.Rectangle
            {
                Width = player.Width,
                Height = player.Height,
                Fill = Brushes.CornflowerBlue,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Canvas.SetLeft(playerShape, player.X);
            Canvas.SetTop(playerShape, player.Y);
            GameCanvas.Children.Add(playerShape);

            foreach (var boulder in boulders)
            {
                var boulderShape = new Avalonia.Controls.Shapes.Rectangle
                {
                    Width = boulder.Width,
                    Height = boulder.Height,
                    Fill = Brushes.DimGray,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1
                };
                Canvas.SetLeft(boulderShape, boulder.X);
                Canvas.SetTop(boulderShape, boulder.Y);
                GameCanvas.Children.Add(boulderShape);
            }
        }

        private void Window_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Key == Key.A || e.Key == Key.Left) moveLeft = true;
            if (e.Key == Key.D || e.Key == Key.Right) moveRight = true;
        }

        private void Window_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.Key == Key.A || e.Key == Key.Left) moveLeft = false;
            if (e.Key == Key.D || e.Key == Key.Right) moveRight = false;
        }
    }
}