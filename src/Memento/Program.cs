using History;
using Originator;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Memento Pattern - Editor de Imagens ===\n");

        var editor = new ImageEditor(1920, 1080);
        var history = new EditorHistory(editor);

        history.Save();

        Console.WriteLine("\nAplicando edições\n");
        editor.ApplyBrightness(20);
        history.Save();

        editor.ApplyFilter("Sepia");
        history.Save();

        editor.Rotate(90);
        history.Save();

        editor.Crop(1280, 720);
        history.Save();

        editor.DisplayInfo();
        history.ShowHistory();

        Console.WriteLine("Desfazendo 2x\n");
        history.Undo();
        editor.DisplayInfo();

        history.Undo();
        editor.DisplayInfo();

        Console.WriteLine("Refazendo 1x\n");
        history.Redo();
        editor.DisplayInfo();

        Console.WriteLine("\nBenefícios\n");
        Console.WriteLine("Sem setters públicos - encapsulamento preservado!");
        Console.WriteLine("Só metadados salvos - não os pixels (economia de memória!)");
        Console.WriteLine("Editor cria e restaura seus próprios saves");
        Console.WriteLine("EditorHistory não sabe o que está dentro do Memento");
    }
}