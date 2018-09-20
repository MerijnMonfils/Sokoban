using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sokoban
{
    public class ViewModel
    {
        private InputView _inputView;
        private OutputView _outputView;
        private ParseLevels _parseLevels;
        private Tile _tile;
        private Wall _wall;

        public ViewModel()
        {
            _inputView = new InputView();
            _outputView = new OutputView();
            _parseLevels = new ParseLevels();
           
            

            this.ReadFiles();
        }

        public void ReadFiles()
        {

            //Size of this variable is the amount of rows
            string[] lines = System.IO.File.ReadAllLines(@"C:\level1.txt");

            //Size of this variable is the amount of columns
            string longest = lines.OrderByDescending(s => s.Length).First();


            //Rows and columns are now dynamic depending on the file input. 
            int rows = lines.Length;
            int columns = longest.Length;


            //Loop test to print entire map.
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);

            }

            Console.WriteLine("Rows amount: "  + rows);
            Console.WriteLine("Columns length " + columns );
          
            //Convert String Array to Char Array
            char[][] result = lines.Select(item => item.ToArray()).ToArray();

            for (int x = 0; x < result.Length; x++)
            {
                Console.WriteLine(result[x]);
            }

            for (int j = 0; j < result.Length; j++)
            {
                //Create object for each char. 
                //What kind of Array is needed for this?
                Object[][] characters = new Object[rows][];

             


            }

            Console.ReadLine();
        }
        }

    }


