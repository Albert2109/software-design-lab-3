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
        var imgLocal = new LightImageNode(@"C:\Users\posta\OneDrive\Изображения\SplitCam\8Ksj.gif");
        var imgNet = new LightImageNode("https://media.tenor.com/x8v1oNUOmg4AAAAM/rickroll-roll.gif");
        div.AddChild(ul);
        div.AddChild(imgLocal);
        div.AddChild(imgNet);
        File.WriteAllText("output.html", div.OuterHTML);
       
        Console.WriteLine("Завантаження зображень завершено.");
    }
}