using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FileTypeConverter
{


    public class Operations
    {
        public readonly static StringBuilder Data = new StringBuilder();
        //public static List<ObjectData> @ObjectData { get; set; } = new List<ObjectData>();
        public static void GetDocs()
        {
            var assembly = Assembly.GetExecutingAssembly();

            Utility.PrintColorMessage(ConsoleColor.DarkCyan, "Assembly name: " + assembly.FullName);

            Console.WriteLine();

            Type[] types = assembly.GetTypes();



            foreach (Type type in types)
            {
                DisplayType(type);

                DisplayConstructor(type);

                DisplayProperties(type);

                DisplayMethods(type);

                Console.WriteLine();

            }



        }



        private static void DisplayMethods(Type type)
        {
            var methods = type.GetMethods();

            foreach (var method in methods)
            {
                var documentattribute = (DocumentAttribute)method.GetCustomAttribute(typeof(DocumentAttribute));

                if (documentattribute != null)
                {
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Method: " + method.Name);

                    Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Description: " + documentattribute.Description);

                    if (!string.IsNullOrEmpty(documentattribute.Input))
                    {
                        Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Input: " + documentattribute.Input);
                    }

                    if (!string.IsNullOrEmpty(documentattribute.Output))
                    {
                        Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Output: " + documentattribute.Output + "\n");
                    }
                }
            }
        }





        // Display properties

        private static void DisplayProperties(Type type)
        {

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                //Gets custom attribute  to property variable. The returned attribute is then being assigned to the documentattribute variable.
                var documentattribute = (DocumentAttribute)property.GetCustomAttribute(typeof(DocumentAttribute));

                if (documentattribute != null)
                {
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Property: " + property.Name);

                    Utility.PrintColorMessage(ConsoleColor.Cyan, "\t Description: " + documentattribute.Description + "\n");
                }


            }
        }


        //// Display constructors
        private static void DisplayConstructor(Type type)
        {

            var constructors = type.GetConstructors();

            foreach (var constructor in constructors)
            {
                var documentattribute = (DocumentAttribute)constructor.GetCustomAttribute(typeof(DocumentAttribute));

                if (documentattribute != null)
                {
                    Utility.PrintColorMessage(ConsoleColor.Cyan, "\t Constructor: " + constructor.Name);

                    Utility.PrintColorMessage(ConsoleColor.Cyan, "\t Description: " + documentattribute.Description);

                    if (!string.IsNullOrEmpty(documentattribute.Input))
                    {
                        Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Input: " + documentattribute.Input);
                    }

                    if (!string.IsNullOrEmpty(documentattribute.Output))
                    {
                        Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Output: " + documentattribute.Output + "\n");
                    }
                }

            }
        }

        private static void DisplayType(Type type)
        {
            var documentAttribute = (DocumentAttribute)type.GetCustomAttribute(typeof(DocumentAttribute));

            if (documentAttribute != null && type.IsClass)
            {
                Utility.PrintColorMessage(ConsoleColor.Yellow, "Class: " + type.Name);

                Utility.PrintColorMessage(ConsoleColor.Yellow, "Description: " + documentAttribute.Description);

                Console.WriteLine();

            }
            else if (documentAttribute != null && type.IsEnum)
            {
                Utility.PrintColorMessage(ConsoleColor.Cyan, "Enum: " + type.Name);

                Utility.PrintColorMessage(ConsoleColor.Cyan, "Description: " + documentAttribute.Description + "\n");

                Console.WriteLine();
            }
            else if (documentAttribute != null && type.IsInterface)
            {
                Utility.PrintColorMessage(ConsoleColor.Cyan, "Interface: " + type.Name);

                Utility.PrintColorMessage(ConsoleColor.Cyan, "Description: " + documentAttribute.Description + "\n");
            }
        }
    }
}
