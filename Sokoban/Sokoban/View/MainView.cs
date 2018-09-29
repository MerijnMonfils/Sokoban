using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sokoban.ViewModel;

namespace Sokoban.View
{
    public class MainView
    {
        private InputViewVM input;
        

        public MainView(OutputViewVM output)
        {
            // input = new InputViewVM(this, output, parse);


        }

        public void StartScreen()
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
            Console.WriteLine("|. : vloer" + 
                "                     |   Naar de bestemming|");

            Console.WriteLine("|O : krat                      |                     |");
            Console.WriteLine("|0 : krat op bestemming        |                     |");
            Console.WriteLine("|x : bestemming                |                     |");
            Console.WriteLine("|@ : truck                     |                     |");
            Console.WriteLine("______________________________________________________");


            Console.WriteLine("> Kies een doolhof (1 - " + input.GetAmountOfLevels() +  "), s = stop");
            Console.WriteLine("Enjoy!");
        }

        public void StartListening()
        {

            
            string s = Console.ReadLine();
            input.StartLevel(s);

            
        }

        public void Write(string line)
        {
            Console.Write(line);
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

    }
}
