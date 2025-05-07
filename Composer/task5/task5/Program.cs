using System.Text;
using task5;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var root = new LightElementNode("div");
        root.AddClass("container");

        var ul = new LightElementNode("ul");
        ul.AddClass("list");

        root.AddChild(ul);

        for (int i = 1; i <= 3; i++)
        {
            var li = new LightElementNode("li");
            li.AddChild(new LightTextNode($"Item {i}"));
            ul.AddChild(li);
        }

        Console.WriteLine("\nПочатковий рендер\n");
        Console.WriteLine(root.Render());

        var second = ul.Children.OfType<LightElementNode>().Skip(1).First();
        ul.RemoveChild(second);

        Console.WriteLine("\nПісля видалення другого елемента\n");
        Console.WriteLine(root.Render());
    }
}