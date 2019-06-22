using System;
using System.Collections.Generic;

namespace ConsoleAppChessKnight
{
    class Knight
    {
        #region members
        /// <summary>
        /// All possible Knight moves from the same square
        /// </summary>
        private static List<Tuple<int, int>> knightMoves = new List<Tuple<int, int>>
        {
            Tuple.Create(2, -1),
            Tuple.Create(2, 1),
            Tuple.Create(1, 2),
            Tuple.Create(-1, 2),
            Tuple.Create(-2, 1),
            Tuple.Create(-2, -1),
            Tuple.Create(-1, -2),
            Tuple.Create(1, -2)
        };
        #endregion

        #region methods
        /// <summary>
        /// Gets a list of squares where the Knight can move within the chessboard
        /// </summary>
        /// <param name="square">The square from which the Knight moves</param>
        /// <returns>List of all squares where the Knight can move</returns>
        public List<Square> GetPossibleMoves(Square square)
        {
            List<Square> nearbySquares = new List<Square>();

            foreach (Tuple<int, int> moves in knightMoves)
            {
                int knightColumn = moves.Item1;
                int knightRow = moves.Item2;

                if (Square.IsValidMove(square, knightColumn, knightRow))
                {
                    nearbySquares.Add(new Square(square.Column + knightColumn, square.Row + knightRow));
                }
            }
            return nearbySquares;
        }
        #endregion
    }
}
