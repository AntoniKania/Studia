using System;
using System.IO;

namespace pliki
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("./data.csv");

            double[] I = new double[lines.Length];
            double[] V = new double[lines.Length];
            double[] P = new double[lines.Length];
            double[] integral = new double[lines.Length];
            string[] temp = new string[2];



            for (int i = 1; i < lines.Length; i++)
            {
                temp = lines[i].Split(",");

                I[i] = Math.Round(10 * (double.Parse(temp[0].Replace(".", ","))), 2);
                V[i] = double.Parse(temp[1].Replace(".", ","));
                P[i] = Math.Round(I[i] * V[i], 2);
                if (i < lines.Length - 1)
                    integral[i] = Math.Round((P[i] + P[i + 1]) / 2, 2);
            }

            string output = "t[us];I[A];U[V];P[W];calka" + "\r\n";

            for (int i = 1; i < lines.Length; i++)
                output += i + ";" + I[i] + ";" + V[i] + ";" + P[i] + ";" + integral[i] + "\r\n";

            //output = output.Replace(",", ".");
            //output = output.Replace(";", ",");

            File.WriteAllText("./output.csv", output);
        }
    }
}
