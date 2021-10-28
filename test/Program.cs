using System;
using static System.Console;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyPressed = ReadKey();

            while(true)
            {
                //int answer;
                //int.TryParse(Console.ReadLine(), out answer);
                if(keyPressed.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.Write("Wcisnales 1");
                }
                else if(keyPressed.Key != ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.Write("Wcisnales zly przycisk, probuj dalej \n");
                }
            }   

            
        }
    }
}
