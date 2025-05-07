using System;
using task5;

internal class Program
{
    private static void Main()
    {
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
    }
}