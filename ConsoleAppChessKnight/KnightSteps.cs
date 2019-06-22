using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppChessKnight
{
    class KnightSteps
    {
        #region methods
        /// <summary>
        /// Calculates the steps which the Knight could move through from the Start square to the End square
        /// </summary>
        /// <param name="start">Starting square</param>
        /// <param name="end">Ending square</param>
        /// <param name="knight">The current Knight that moving</param>
        /// <returns>A list of calculated steps</returns>
        public static List<Square> CalculateKnightSteps(Square start, Square end, Knight knight)
        {
            Queue<List<Square>> stepsQueue = new Queue<List<Square>>();
            List<Square> visitedSquares = new List<Square>();
            List<Square> startSquare = new List<Square>();
            startSquare.Add(start);
            stepsQueue.Enqueue(startSquare);
            visitedSquares.Add(start);

            while (stepsQueue.Count != 0)
            {
                List<Square> currentSteps = stepsQueue.Dequeue();
                Square currentSquare = currentSteps.Last();

                if ((currentSquare.Column == end.Column) && (currentSquare.Row == end.Row))
                    return currentSteps;

                foreach (Square nearbySquare in knight.GetPossibleMoves(currentSquare))
                {
                    if (!visitedSquares.Any(square => (square.Column == nearbySquare.Column && square.Row == nearbySquare.Row)))
                    {
                        List<Square> stepsBranch = new List<Square>();
                        stepsBranch.AddRange(currentSteps);
                        stepsBranch.Add(nearbySquare);
                        visitedSquares.Add(nearbySquare);
                        stepsQueue.Enqueue(stepsBranch);
                    }
                }
            }
            return new List<Square>();
        }

        /// <summary>
        /// Gets a string output of the Knight's found steps 
        /// </summary>
        /// <param name="steps"></param>
        /// <returns></returns>
        public static string GetKnightSteps(List<Square> steps)
        {
            if (steps.Count == 0)
                return "No steps found!";

            steps.RemoveAt(0);
            string knightStepsSquares = "";
            foreach (Square square in steps)
            {
                knightStepsSquares += square.SquareStringValue() + " ";
            }

            return String.Format("It takes {0} steps ( {1}) for the Knight to move from the Start square to the End square",
                (steps.Count).ToString(), knightStepsSquares);
        }
        #endregion
    }
}
