using System;

namespace pierwsze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj n: ");
            int n = int.Parse(Console.ReadLine());

            double[] nbr = new double[n];

            for(int i = 2; i < n; i++)
            {
                nbr[i] = i;
            }

            for(int i = 2; i < Math.Sqrt(n); i++)
            {
                for(int j = 2; j <= n; j++)
                {
                    if (i * j < n)
                        nbr[i * j] = 0;
                    else
                        break;
                }    
                
            }
            for(int i = 0; i < n; i++)
            {
                if (nbr[i] != 0)
                    Console.Write(i + " ");
            }
        }
    }
}
//test github