using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class ParseLevels
    {
        public void ReadFiles()
        {

            //Size of this variable is the amount of rows
            string[] lines = System.IO.File.ReadAllLines(@"C:\level1.txt");

            //Size of this variable is the amount of columns
            string longest = lines.OrderByDescending(s => s.Length).First();

            //Amount of characters in the txt file
            int amountOfChars = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                //Add the lenght of each row to determine the amount of chars
                amountOfChars += lines[i].Length;
            }

            //Rows and columns are now dynamic depending on the file input. 
            int rows = lines.Length;
            int columns = longest.Length;

            //Create array
     
            Object[,] characters = new object[rows, columns];

        }
    }
}