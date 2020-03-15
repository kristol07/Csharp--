using System;
using System.Reflection;

namespace CsharpTest
{
    public class Reflection
    {
        public static void Test()
        {
            Assembly asm = Assembly.LoadFrom("Microsoft.CSharp.dll");
            Console.WriteLine(asm.FullName);
            foreach (var type in asm.DefinedTypes)  // asm.GetTypes()
            {
                Console.WriteLine("==========");
                Console.WriteLine("Class Name: {0}", type.Name);
                Console.WriteLine("Namespace: {0}", type.Namespace);
                Console.WriteLine("Fields: ");
                foreach (var field in type.GetFields())
                {
                    Console.WriteLine(field);
                }
                Console.WriteLine("Properties: ");
                foreach (var property in type.GetProperties())
                {
                    Console.WriteLine(property);
                }
                // Console.WriteLine("Methods: ");
                // foreach (var method in type.GetMethods())
                // {
                //     Console.WriteLine(method);
                // }
            }

        }
    }
}