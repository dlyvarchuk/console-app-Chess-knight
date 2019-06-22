using System;

namespace ConsoleAppChessKnight
{
    class Square
    {
        #region members
        private static int maxColumns = 8;
        private static int maxRows = 8;

        private static char minColumnChar = 'A';
        private static char minRowChar = '1';

        private int column;
        private int row;
        #endregion

        #region properties
        public int Column { get { return column; } }
        public int Row { get { return row; } }
        #endregion

        #region methods
        /// <summary>
        /// Checks if the Square position string input correct and parse it to column and row
        /// </summary>
        /// <param name="position"></param>
        public Square(string position)
        {
            position = position.ToUpper();

            if (position.Length != 2)
            {
                throw new ArgumentException("Wrong input");
            }

            if (position[0] >= minColumnChar + maxColumns || position[0] < minColumnChar)
            {
                throw new ArgumentException("Wrong input");
            }

            if (position[1] >= minRowChar + maxRows || position[1] < minRowChar)
            {
                throw new ArgumentException("Wrong input");
            }

            column = position[0] - minColumnChar;
            row = position[1] - minRowChar;
        }

        /// <summary>
        /// Checks if column and row integer are in the specified range of a chess board squares
        /// and assigns these values to the current Square
        /// </summary>
        /// <param name="column">Column to check</param>
        /// <param name="row">Row to check</param>
        public Square(int column, int row)
        {
            if ((column >= 0 && column < maxColumns) && (row >= 0 && row < maxRows))
            {
                this.column = column;
                this.row = row;
            }
            else
            {
                throw new ArgumentException("Row and column are outside the specified range");
            }
        }

        /// <summary>
        /// Gets the calculated Squares' string values 
        /// </summary>
        /// <returns>String of calculated Squares through which the Knight has passed</returns>
        public string SquareStringValue()
        {
            char[] chars = { (char)(minColumnChar + Column), (char)(minRowChar + Row) };

            return new string(chars);
        }

        /// <summary>
        /// Defines if the Knight can move in the current way 
        /// </summary>
        /// <param name="square">The Square where the Knight is at the moment</param>
        /// <param name="columnMove">Steps number to move to the column</param>
        /// <param name="rowMove">Steps number to move to the row</param>
        /// <returns>Validness of the move</returns>
        public static bool IsValidMove(Square square, int columnMove, int rowMove)
        {
            bool correctCol = (square.column + columnMove >= 0) && (square.column + columnMove < maxColumns);
            bool correctRow = (square.row + rowMove >= 0) && (square.row + rowMove < maxRows);

            return (correctCol && correctRow);
        }
        #endregion

    }
}
