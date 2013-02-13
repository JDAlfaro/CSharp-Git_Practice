// Basic "Hello World" in CSharp
// Example from http://msdn.microsoft.com/en-ca/library/vstudio/k1sx6ed2.aspx

using System;
namespace HelloWorld
{
    class Hello
    {
        static void Main()
        {
            Console.WriteLine("Hello World!!");
            Console.WriteLine("My name is JDAlfaro");

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}