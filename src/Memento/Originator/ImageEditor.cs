using Memento;

namespace Originator
{
    public class ImageEditor
    {
        private int _width;
        private int _height;
        private int _brightness;
        private string _filter;
        private double _rotation;

        public ImageEditor(int width, int height)
        {
            _width = width;
            _height = height;
            _brightness = 0;
            _filter = "None";
            _rotation = 0;
            Console.WriteLine($"[Editor] Imagem criada: {width}x{height}");
        }

        public void ApplyBrightness(int value)
        {
            _brightness += value;
            Console.WriteLine($"[Editor] Brilho: {_brightness}");
        }

        public void ApplyFilter(string filter)
        {
            _filter = filter;
            Console.WriteLine($"[Editor] Filtro: {filter}");
        }

        public void Rotate(double degrees)
        {
            _rotation += degrees;
            Console.WriteLine($"[Editor] Rotação: {_rotation}°");
        }

        public void Crop(int width, int height)
        {
            _width = width;
            _height = height;
            Console.WriteLine($"[Editor] Crop: {width}x{height}");
        }

        public ImageMemento Save()
            => new ImageMemento(_brightness, _filter, _rotation, _width, _height);

        public void Restore(ImageMemento memento)
        {
            _brightness = memento.Brightness;
            _filter = memento.Filter;
            _rotation = memento.Rotation;
            _width = memento.Width;
            _height = memento.Height;
            Console.WriteLine($"[Editor] Estado restaurado: {memento}");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"\n=== Estado Atual ===");
            Console.WriteLine($"Dimensões: {_width}x{_height}");
            Console.WriteLine($"Brilho: {_brightness}");
            Console.WriteLine($"Filtro: {_filter}");
            Console.WriteLine($"Rotação: {_rotation}°\n");
        }
    }
}