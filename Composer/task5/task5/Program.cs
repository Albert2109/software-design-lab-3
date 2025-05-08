using System;
using task5;

internal class Program
{
    private static void Main()
    {
      
        var root = new LightElementNode("div");
        root.AddClass("container");

        var ul = new LightElementNode("ul");
        ul.AddClass("list");
        ul.AddChild(new LightElementNode("li") { Children = { new LightTextNode("Item 1") } });
        ul.AddChild(new LightElementNode("li") { Children = { new LightTextNode("Item 2") } });
        ul.AddChild(new LightElementNode("li") { Children = { new LightTextNode("Item 3") } });
        root.AddChild(ul);

       
        var img = new LightElementNode("img", isSelfClosing: true);
        root.AddChild(img);
        var link = new LightElementNode("a");
        link.AddChild(new LightTextNode("click here"));
        root.AddChild(link);
        var p = new LightElementNode("p");
        p.AddChild(new LightTextNode("Just a paragraph"));
        root.AddChild(p);

       
        Console.WriteLine(root.OuterHTML);

      
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