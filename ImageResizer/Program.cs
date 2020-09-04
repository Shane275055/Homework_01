using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw.Stop();

            float ori = sw.ElapsedMilliseconds;

            imageProcess.Clean(destinationPath);

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            var task = imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
            sw2.Stop();

            float asy = sw2.ElapsedMilliseconds;

            Console.WriteLine($"同步花費時間: {ori} ms");
            Console.WriteLine($"異步花費時間: {asy} ms");
            Console.WriteLine($"花費時間百分比: {(ori - asy) / ori * 100} %");
            Console.ReadLine();
        }
    }
}
