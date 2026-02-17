using Memento;
using Originator;

namespace History
{
    public class EditorHistory
    {
        private readonly ImageEditor _editor;
        private readonly Stack<ImageMemento> _undoStack = new();
        private readonly Stack<ImageMemento> _redoStack = new();

        public EditorHistory(ImageEditor editor) => _editor = editor;

        public void Save()
        {
            var memento = _editor.Save();
            _undoStack.Push(memento);
            _redoStack.Clear();
            Console.WriteLine($"[History] Salvo | Snapshots: {_undoStack.Count}");
        }

        public void Undo()
        {
            if (_undoStack.Count == 0)
            {
                Console.WriteLine("[History] Nada para desfazer!");
                return;
            }

            var current = _editor.Save();
            _redoStack.Push(current);

            var memento = _undoStack.Pop();
            _editor.Restore(memento);
        }

        public void Redo()
        {
            if (_redoStack.Count == 0)
            {
                Console.WriteLine("[History] Nada para refazer!");
                return;
            }

            var current = _editor.Save();
            _undoStack.Push(current);

            var memento = _redoStack.Pop();
            _editor.Restore(memento);
        }

        public void ShowHistory()
        {
            Console.WriteLine("\n=== Histórico de Saves ===");
            int i = _undoStack.Count;
            foreach (var memento in _undoStack)
                Console.WriteLine($"  {i--}. {memento}");
        }
    }
}