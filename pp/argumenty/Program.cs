using System;
using System.Collections.Generic;

namespace argumenty
{
    class Program
    {
        static void Main(string[] args)
        {

            /*DateTime date = new DateTime(2021, 12, 1, 12, 0, 0);

            DateTime dt1 = date.AddSeconds(30);
            DateTime dt2 = date.AddMinutes(-5);
            DateTime dt3 = date.AddHours(2);
            DateTime dt4 = date.AddDays(7);
            DateTime dt5 = date.AddMonths(-3);
            DateTime dt6 = date.AddYears(1);
            */

            /*if (ymd.Length == 3)
           {
               int.TryParse(ymd[0], out year);
               int.TryParse(ymd[1], out month);
               int.TryParse(ymd[2], out day);
           }
           else
               System.Console.WriteLine("Podales zle dane");

           if (hms.Length == 3)
           {
               int.TryParse(hms[0], out hour);
               int.TryParse(hms[1], out minutes);
               int.TryParse(hms[2], out seconds);
           }
           else
               System.Console.WriteLine("Podales zle dane");
           */

            //List<string> data = new List<string>(args.Split('.'));

            string[] ymd = args[0].Split('-');
            string[] hms = args[1].Split(':');

            int day = int.Parse(ymd[2]);
            int month = int.Parse(ymd[1]);
            int year = int.Parse(ymd[0]);

            int hour = int.Parse(hms[0]);
            int minutes = int.Parse(hms[1]);
            int seconds = int.Parse(hms[2]);

            int s = 0;
            int m = 0;
            int h = 0;
            int d = 0;
            int mo = 0;
            int y = 0;

            for (int i = 2; i < args.Length; i++)
            {

            }


            DateTime date = new DateTime(year, month, day, hour, minutes, seconds);

            DateTime dt1 = date.AddSeconds(s);
            DateTime dt2 = date.AddMinutes(m);
            DateTime dt3 = date.AddHours(h);
            DateTime dt4 = date.AddDays(d);
            DateTime dt5 = date.AddMonths(mo);
            DateTime dt6 = date.AddYears(y);



        }
    }
}
