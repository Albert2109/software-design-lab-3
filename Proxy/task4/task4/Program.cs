using task4;

internal class Program
{
    static void Main()
    {
        string filePath = "test.txt";
        File.WriteAllText(filePath, "Hello\nWorld!");

        Console.WriteLine("Using SmartTextChecker:");
        SmartTextChecker checker = new SmartTextChecker(filePath);
        checker.ReadFile();

        Console.WriteLine("\nUsing SmartTextReaderLocker:");
        SmartTextReaderLocker locker = new SmartTextReaderLocker(filePath, @"forbidden.txt");
        locker.ReadFile();
    }
}