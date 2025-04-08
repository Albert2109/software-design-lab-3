using task5;

internal class Program
{
    static void Main()
    {
        string url = "https://www.gutenberg.org/cache/epub/1513/pg1513.txt";
        string bookText = DownloadText(url);

        string[] lines = bookText.Split('\n');
        LightElementNode body = new LightElementNode("body");

        foreach (string line in lines)
        {
            string trimmed = line.Trim();
            if (string.IsNullOrEmpty(trimmed)) continue;

            LightElementNode element;
            if (body.Children.Count == 0) element = LightElementFactory.CreateElement("h1");
            else if (trimmed.Length < 20) element = LightElementFactory.CreateElement("h2");
            else if (line.StartsWith(" ")) element = LightElementFactory.CreateElement("blockquote");
            else element = LightElementFactory.CreateElement("p");

            element.AddChild(new LightTextNode(trimmed));
            body.AddChild(element);
        }

        string htmlContent = "<html><head><meta charset='UTF-8'><title>Book</title></head>" + body.OuterHTML + "</html>";
        File.WriteAllText("output.html", htmlContent);

        Console.WriteLine("HTML-файл збережено як output.html");
        Console.WriteLine($"Memory used: {GC.GetTotalMemory(true)} bytes");
    }

    static string DownloadText(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            return client.GetStringAsync(url).Result;
        }
    }
}