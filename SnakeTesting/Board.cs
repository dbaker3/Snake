using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    // The gameboard. Has a playfield 2d array. Array elements have a 
    // state showing what they contain : empty, food, snake

    static class Board
    {
        public const int PlayfieldWidth = 50;
        public const int PlayfieldHeight = 50;

        public enum PositionStates
        {
            empty, food, snake
        }       

        private static PositionStates[,] Playfield = new PositionStates[PlayfieldWidth, PlayfieldHeight];

        static Board() // Initialize all spaces empty
        {
            for (int i = 0; i < PlayfieldWidth; i++)
            {
                for (int j = 0; j < PlayfieldHeight; j++)
                {
                    Playfield[i, j] = PositionStates.empty;
                }
            }
        }

        public static void SetPositionStatus(int x, int y, PositionStates state)
        {
            Playfield[x, y] = state;
        }

        public static PositionStates GetPositionStatus(int x, int y)
        {
            return Playfield[x, y];
        }

      

    }
}
