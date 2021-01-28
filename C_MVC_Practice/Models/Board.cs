using System;
using System.Collections.Generic;
using System.Linq;

namespace C_MVC_Practice.Models
{
    public class Board
    {
        public List<Square> Squares { get; private set; }

        public Board()
        {
            Squares = new List<Square>();

            for(int row = 1; row < 10; row++)
            {
                for(int column = 1; column < 10; column++)
                {
                    Squares.Add(new Square(row, column));
                }
            }
        }

        public void SetSquareValue(int row, int column, int value)
        {
            Square activeSquare = Squares.Single(x => (x.Row == row) && (x.Column == column));
            activeSquare.Value = value;

            //Remove value from other squares in the same row
            foreach (Square square in Squares.Where(s => !s.isSolved && (s.Row == row)))
            {
                square.PotentialValues.Remove(value);
            }

            //Remove value from other squares in the same column
            foreach (Square square in Squares.Where(s => !s.isSolved && (s.Column == column)))
            {
                square.PotentialValues.Remove(value);
            }

            //Remove value from other squares in the same quadrant
            foreach(Square square in Squares.Where(s => !s.isSolved && (s.Block == activeSquare.Block)))
            {
                square.PotentialValues.Remove(value);
            }

            //Remove the Value for any square that only have on remaining PotentialValue
            foreach(Square square in Squares.Where(s => !s.isSolved && (s.PotentialValues.Count == 1)))
            {
                SetSquareValue(square.Row, square.Column, square.PotentialValues[0]);
            }
        }
    }
}
