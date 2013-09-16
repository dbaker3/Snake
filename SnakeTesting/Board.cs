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
        public const int PlayfieldWidth = 30;
        public const int PlayfieldHeight = 30;

        public static int FoodX { get; set; }
        public static int FoodY { get; set; }

        private static Random rand = new Random();

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

        public static void PlaceFood(List<SnakeSegment> segments)
        {
            bool placedWhereSnakeIs = true;
            // Make sure food isn't placed where snake currently is
            while (placedWhereSnakeIs)
            {

                FoodX = rand.Next(PlayfieldWidth);
                FoodY = rand.Next(PlayfieldHeight);

                foreach (SnakeSegment seg in segments)
                {
                    if (seg.X != FoodX && seg.Y != FoodY)
                        placedWhereSnakeIs = false;
                    else
                    {
                        placedWhereSnakeIs = true;
                        break;
                    }
                }

            }
            
            SetPositionStatus(FoodX, FoodY, PositionStates.food);
        }

    }
}
