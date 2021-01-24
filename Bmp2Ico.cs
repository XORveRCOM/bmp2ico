// > C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\csc.exe /t:exe Bmp2Ico.cs
using System;
using System.IO;
using System.Drawing;

namespace Bmp2Ico {
    public class Bmp2Ico {
        public static void Main(string[] argv) {
            if (argv.Length == 0) {
                Console.Out.WriteLine("\tBmp2Ico bitmap-file");
                return;
            }
            string bmpfile = Path.GetFullPath(argv[0]);
            if (!File.Exists(bmpfile)) {
                Console.Out.WriteLine("\t{0} is not exists.", bmpfile);
                return;
            }
            if (Path.GetExtension(bmpfile).ToLower() == ".ico") {
                return;
            }
            FileStream fs = new FileStream(bmpfile, FileMode.Open, FileAccess.Read);
            Bitmap bmp = new Bitmap(fs);
            fs.Close();
            Icon ico = Icon.FromHandle(bmp.GetHicon());
            fs = new FileStream(Path.ChangeExtension(bmpfile, ".ico"), FileMode.Create, FileAccess.Write);
            ico.Save(fs);
            fs.Close();
            ico.Dispose();
        }
    }
}
