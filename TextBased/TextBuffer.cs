using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBased
{
    class TextBuffer
    {
        private static string outputBuff;

        public static void Add(string text)
        {
            outputBuff += text + "\n";
        }
        public static void Display()
        {
            Console.Clear();

            Console.Write(TextUtils.WordWrap(outputBuff, Console.WindowWidth));

            Console.WriteLine("What will you do?");
            Console.Write(">");

            outputBuff = "";
        }
    }
}
