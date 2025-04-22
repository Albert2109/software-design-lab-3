using System.Text;
using task1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
       Logger logger = new Logger();
        logger.Log("rttrkhyrthr");
        logger.Error("ergrehyrtytj");
        logger.Warn("regrthytjtuyutkytuk");
        FileWriter writer = new FileWriter();
        Console.WriteLine("Файл зберігається тут: " + Path.GetFullPath("file.txt"));
        writer.ClearFile(); 
        writer.Write("rthrtjytljyt yut jytyt");
        writer.WriteLine("th rthytjytjyu yutjyutj");
        FileLogger fileLogger = new FileLogger();
        fileLogger.Log("reghrtjhrtejtr rthrthrht");
        fileLogger.Error("erg trh rth yr rt y hy juytj ty");
        fileLogger.Warn("r rt rt rt rth trhtrh rt h trhrt");
    }
}