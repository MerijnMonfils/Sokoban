using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class OutputView
    {

        public void startScreen()
        {
            Console.WriteLine("______________________________________________________");
            Console.WriteLine("|                              |                     |");
            Console.WriteLine("|Welkom bij Sokoban!           |                     |");
            Console.WriteLine("|                              |                     |");
            Console.WriteLine("|                              |                     |");
            Console.WriteLine("|Betekenis van de symbolen" + 
                "     |   doel van het spel:|");

            Console.WriteLine("|Spatie : outerspace" + 
                "           |    Duw met de truck |");
            Console.WriteLine("|█ : muur" +
                "                      |    de krat(ten)     |");
            Console.WriteLine(". : vloer" + 
                "                      |   Naar de bestemming|");

            Console.WriteLine("|O : krat                      |                     |");
            Console.WriteLine("|0 : krat of bestemming        |                     |");
            Console.WriteLine("|x : bestemming                |                     |");
            Console.WriteLine("|@ : truck                     |                     |");
            Console.WriteLine("______________________________________________________");


            Console.WriteLine("> Kies een doolhof (1 -4), s = stop");
            Console.WriteLine("Enjoy!");
            string s = Console.ReadLine();

            if (s.Equals("s")) {
                Environment.Exit(0);
            }else if (s.Equals"1") {

            }
            {
                Console.WriteLine(s);
            }

        }

    }
}