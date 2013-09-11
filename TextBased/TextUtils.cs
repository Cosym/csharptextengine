using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBased
{
    class TextUtils
    {
        //Input Processors
        //Extracts the command from the input you use (first word)
        public static string ExtractCmd(string line)
        {
            int index = line.IndexOf(' ');
            if (index == -1)
                return line;
            else
                return line.Substring(0, index);
        }
        //Extracts the argument from the input you use (second word)
        public static string ExtractArgs(string line)
        {
            int index = line.IndexOf(' ');
            if (index == -1)
                return "";
            else
                return line.Substring(index + 1, line.Length - index - 1);
        }

        //----------
        //Word wrap so that words do not get cut off based on the width of the console, not everything needs to be passed through here but 
        //larger strings should pass through this
        public static string WordWrap(string text, int bufferWidth)
        {
            string result = "";
            string[] lines = text.Split('\n');

            foreach (string line in lines)
            {
                int lineLength = 0;
                string[] words = line.Split(' ');

                foreach (string word in words)
                {
                    if (word.Length + lineLength >= bufferWidth - 1)
                    {
                        result += "\n";
                        lineLength = 0;
                    }
                    result += word + " ";
                    lineLength += word.Length + 1;
                }
                result += "\n";
            }
            return result;
        }
    }
}
