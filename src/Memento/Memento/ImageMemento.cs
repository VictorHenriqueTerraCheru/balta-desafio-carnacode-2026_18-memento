namespace Memento
{
    public class ImageMemento
    {
        public int Brightness { get; }
        public string Filter { get; }
        public double Rotation { get; }
        public int Width { get; }
        public int Height { get; }
        public DateTime SavedAt { get; }

        public ImageMemento(int brightness, string filter, double rotation, int width, int height)
        {
            Brightness = brightness;
            Filter = filter;
            Rotation = rotation;
            Width = width;
            Height = height;
            SavedAt = DateTime.Now;
        }

        public override string ToString()
            => $"[{SavedAt:HH:mm:ss}] {Width}x{Height} | Brilho:{Brightness} | Filtro:{Filter} | Rotação:{Rotation}°";
    }
}