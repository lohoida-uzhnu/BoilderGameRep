using Avalonia; // Змінено з System.Windows

namespace BoulderGame // Твій неймспейс
{
    public class GameObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Rect Bounds => new Rect(X, Y, Width, Height);
    }

    public class Player : GameObject
    {
        public double Speed { get; set; } = 7.0;
    }

    public class Boulder : GameObject
    {
        public double Speed { get; set; }
    }
}