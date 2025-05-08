using task5;

internal class Program
{
    private static void Main()
    {
        var div = new LightElementNode("div");
        div.AddClass("container");
        var ul = new LightElementNode("ul");
        ul.AddClass("list");
        ul.AddChild(new LightElementNode("li") { Children = { new LightTextNode("Item 1") } });
        ul.AddChild(new LightElementNode("li") { Children = { new LightTextNode("Item 2") } });
        ul.AddChild(new LightElementNode("li") { Children = { new LightTextNode("Item 3") } });
        div.AddChild(ul);
        Console.WriteLine("Depth-First Traversal");
        var dfsIt = div.CreateIterator();
        while (dfsIt.MoveNext())
            Console.WriteLine(dfsIt.Current.OuterHTML);
        Console.WriteLine("CSS Selector Iterator (.list)");
        var cssIt = new FilterIterator<LightNode>(
            div.CreateIterator(),
            node => node is LightElementNode el && el.Classes.Contains("list")
        );
        while (cssIt.MoveNext())
            Console.WriteLine(((LightElementNode)cssIt.Current).OuterHTML);
    }
}