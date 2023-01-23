using System;
using System.IO;

namespace WriteToText
{
    public class CreateAndWriteToFile
    {
        public static void CreateAndWrite(string text, string fileName)
        {
            using (StreamWriter writer = File.CreateText(fileName))
            {
                writer.Write(text);
                writer.Write(writer.NewLine);
            }
        }
    }
}
