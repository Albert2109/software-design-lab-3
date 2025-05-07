using task5;

internal class Program
{
    private static void Main()
    {
        var appRoot = new LightElementNode("div");
        appRoot.AddClass("container");
        var ul = new LightElementNode("ul");
        ul.AddClass("list");
        ul.AddChild(new LightElementNode("li") { Children = { new LightTextNode("Item 1") } });
        ul.AddChild(new LightElementNode("li") { Children = { new LightTextNode("Item 2") } });
        ul.AddChild(new LightElementNode("li") { Children = { new LightTextNode("Item 3") } });
        appRoot.AddChild(ul);
        Console.WriteLine(appRoot.OuterHTML);
        Console.WriteLine("Macro Command");
        var cmdMgr = new CommandManager();
        var macro = new MacroCommand();
        macro.Add(new AddElementCommand(appRoot, "button"));
        macro.Add(new AddClassCommand(appRoot, "btn-primary"));
        cmdMgr.Execute(macro);
        Console.WriteLine(appRoot.OuterHTML);
        cmdMgr.Undo();
        Console.WriteLine("After undo: " + appRoot.OuterHTML);
    }
}