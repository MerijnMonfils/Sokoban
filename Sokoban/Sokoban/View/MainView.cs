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

        public int _amount { private get; set; }

        public MainView(OutputViewVM output)
        {
            input = new InputViewVM(output, this);
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

            Console.WriteLine("> Kies een doolhof (1 - " + _amount + "), s = stop");
            Console.WriteLine("Enjoy!");
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void StartListening()
        {
            input.LoadLevel(Console.ReadKey().Key);
        }

        public void StartPlaying()
        {
            try
            {
                input.PlayLevel(Console.ReadKey().Key);
            }catch (Exception e)
            {
                StartPlaying();
            }
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
