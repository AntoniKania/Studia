using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                double cos;
                Console.WriteLine("Wpisz liczbe ;)");
                Console.Write(": ");
                double.TryParse(Console.ReadLine(), out cos);
                Console.WriteLine(cos);
                

            }
        }
    }
}
