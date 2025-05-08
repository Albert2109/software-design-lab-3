using System;
using System.Linq;
using System.Text;
using task5;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

       
        var appRoot = new LightElementNode("div");
        appRoot.AddChild(new LightElementNode("p")
        {
            Children = { new LightTextNode("Feeling the vibe!") }
        });
        Console.WriteLine("Press H (happy), S (sad), U (surprise), any other for neutral:");
        var key = Console.ReadKey(true).Key;
        var renderer = new Renderer();
        renderer.HandleInput(key);
        Console.WriteLine(renderer.Render(appRoot));

       
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

        
        Console.WriteLine("\nDepth-First Traversal");
        var dfsIt = root.CreateIterator();
        while (dfsIt.MoveNext())
            Console.WriteLine(dfsIt.Current.OuterHTML);

        Console.WriteLine("\nCSS Selector Iterator (.list)");
        var cssIt = new FilterIterator<LightNode>(
            root.CreateIterator(),
            node => node is LightElementNode el && el.CssClasses.Contains("list")
        );
        while (cssIt.MoveNext())
            Console.WriteLine(((LightElementNode)cssIt.Current).OuterHTML);

        
        Console.WriteLine("\nMacro Command Demo");
        var cmdMgr = new CommandManager();
        var macro = new MacroCommand();
        macro.Add(new AddElementCommand(root, "button"));
        macro.Add(new AddClassCommand(root, "btn-primary"));
        cmdMgr.Execute(macro);
        Console.WriteLine("After Execute:   " + root.OuterHTML);
        cmdMgr.Undo();
        Console.WriteLine("After Undo:      " + root.OuterHTML);
        cmdMgr.Redo();
        Console.WriteLine("After Redo:      " + root.OuterHTML);

 
        Console.WriteLine("\nAccessibility Issues");
        var visitor = new AccessibilityVisitor();
        root.Accept(visitor);
        visitor.Issues.ForEach(Console.WriteLine);
    }
}
