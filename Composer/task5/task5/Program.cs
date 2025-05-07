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
        var img = new LightElementNode("img", isBlock: false, isSelfClosing: true);
        div.AddChild(img);
        var link = new LightElementNode("a");
        link.Children.Add(new LightTextNode("click here"));
        div.AddChild(link);
        var p = new LightElementNode("p");
        p.Children.Add(new LightTextNode("Just a paragraph"));
        div.AddChild(p);
        Console.WriteLine(div.OuterHTML);
        var visitor = new AccessibilityVisitor();
        div.Accept(visitor);
        Console.WriteLine("-- Accessibility Issues --");
        visitor.Issues.ForEach(Console.WriteLine);
    }
}