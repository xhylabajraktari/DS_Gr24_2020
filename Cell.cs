using System;
using System.Collections.Generic;
using System.Text;

namespace TapCode
{
    class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }


        public char Letter { get; set; }

        public Cell(int x, int y, char letter)
        {
            this.X = x;
            this.Y = y;
            this.Letter = letter;
        }
        public Cell()
        {

        }

    }
}
