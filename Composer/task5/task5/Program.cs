using task5;

internal class Program
{
    private static void Main()
    {
        LightElementNode div = new LightElementNode("div");
        div.AddClass("container");

        LightElementNode ul = new LightElementNode("ul");
        ul.AddClass("list");

        ul.AddChild(new LightElementNode("li") { Children = { new LightTextNode("Item 1") } });
        ul.AddChild(new LightElementNode("li") { Children = { new LightTextNode("Item 2") } });
        ul.AddChild(new LightElementNode("li") { Children = { new LightTextNode("Item 3") } });

        div.AddChild(ul);

        Console.WriteLine(div.OuterHTML);
    }
}