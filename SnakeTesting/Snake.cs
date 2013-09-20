using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        List<SnakeSegment> segments;

        public Utility.Movements Direction { set; get; }
       // private Utility.Movements previousDirection { set; get; }
        private enum methodOfDeath { wall, snake, explosion };

        // TODO: keep track of what needs to be drawn and erased --
        //       This will GREATLY speed up drawing since the entire
        //       board will not have to be scanned and drawn each move
        public SnakeSegment SegmentToErase;
        public SnakeSegment SegmentToDraw;

        public int Score { get; private set; }

        public Snake()
        {
            Score = 0;
            Direction = Utility.Movements.right;
            segments = new List<SnakeSegment>();
            segments.Add(new SnakeSegment(4, 2, true, false)); // head
            segments.Add(new SnakeSegment(3, 2, false, false));
            segments.Add(new SnakeSegment(2, 2, false, false));


            Board.PlaceFood(segments); // place initial piece of food

        }
        
        public void Move()
        {

            //foreach (SnakeSegment a in segments)
            //{
            //    System.Windows.Forms.MessageBox.Show(Board.GetPositionStatus(a.X, a.Y).ToString()  );
            //}

         
            int snakeLength = segments.Count;
            for (int i = snakeLength - 1; i >= 0; i--) // Move each segment starting at END OF TAIL
            {
                if (!segments[i].IsNew) // move it if not new
                {
                    if (segments[i].IsHead)
                    {
                        SegmentToDraw = segments[i];

                        switch (Direction)
                        {
                            case Utility.Movements.up:
                                // TODO: boundary check
                                if (segments[i].Y <= 0)
                                    endGame(methodOfDeath.wall);


                                Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.empty);
                                segments[i].Y -= 1;


                                if (Board.GetPositionStatus(segments[i].X, segments[i].Y) == Board.PositionStates.snake)
                                    endGame(methodOfDeath.snake);
                                

                                if (Board.GetPositionStatus(segments[i].X, segments[i].Y) == Board.PositionStates.food)
                                {
                                    Score++;
                                    GrowSegment();
                                    Board.PlaceFood(segments);
                                }

                                break;
                            case Utility.Movements.down:
                                // TODO: boundary check
                                if (segments[i].Y >= Board.PlayfieldHeight - 1)
                                    endGame(methodOfDeath.wall);

                                Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.empty);
                                //segments[i].X = segments[i].X;
                                segments[i].Y += 1;
                                //Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.snake);

                                if (Board.GetPositionStatus(segments[i].X, segments[i].Y) == Board.PositionStates.snake)
                                    endGame(methodOfDeath.snake);

                                if (Board.GetPositionStatus(segments[i].X, segments[i].Y) == Board.PositionStates.food)
                                {
                                    Score++;
                                    GrowSegment();
                                    Board.PlaceFood(segments);
                                }

                                break;
                            case Utility.Movements.left:
                                // TODO: boundary check
                                if (segments[i].X <= 0)
                                    endGame(methodOfDeath.wall);

                                Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.empty);
                                segments[i].X -= 1;
                                //segments[i].Y = segments[i].Y;
                                //Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.snake);

                                if (Board.GetPositionStatus(segments[i].X, segments[i].Y) == Board.PositionStates.snake)
                                    endGame(methodOfDeath.snake);

                                if (Board.GetPositionStatus(segments[i].X, segments[i].Y) == Board.PositionStates.food)
                                {
                                    Score++;
                                    GrowSegment();
                                    Board.PlaceFood(segments);
                                }

                                break;
                            case Utility.Movements.right:
                                // TODO: boundary check
                                if (segments[i].X >= Board.PlayfieldWidth - 1)
                                    endGame(methodOfDeath.wall);

                                Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.empty);
                                segments[i].X += 1;
                                //segments[i].Y = segments[i].Y;
                                //Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.snake);

                                if (Board.GetPositionStatus(segments[i].X, segments[i].Y) == Board.PositionStates.snake)
                                    endGame(methodOfDeath.snake);

                                if (Board.GetPositionStatus(segments[i].X, segments[i].Y) == Board.PositionStates.food)
                                {
                                    Score++;
                                    GrowSegment();
                                    Board.PlaceFood(segments);
                                }

                                break;
                            default:
                                break;
                        }



                    }
                    else // not head
                    { // move to same spot as leading segment 
                        Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.empty);
                        segments[i].X = segments[i - 1].X;
                        segments[i].Y = segments[i - 1].Y;
                        //Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.snake);

                        // for board drawing
                        if (i == snakeLength - 1) // first loop through -- this is the end of tail piece so erase it
                            SegmentToErase = segments[i];
                    }

                }
                else // was new so it didn't move - mark it not new for next time
                {
                    segments[i].IsNew = false;
                    //Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.empty);

                    // Don't mark it to erase since it didn't move
                    SegmentToErase = null;
                }

                foreach (SnakeSegment seg in segments)
                {
                    Board.SetPositionStatus(seg.X, seg.Y, Board.PositionStates.snake);
                }

                
            }
          
        }

        public void GrowSegment()
        {
            int numSegments = segments.Count;
            int leaderX = segments[numSegments - 1].X;
            int leaderY = segments[numSegments - 1].Y;

            // add segment to list
            // give it same location as butt
            segments.Add(new SnakeSegment(leaderX, leaderY));
            // don't move it on next slither (implemented in Move method)
            //System.Windows.Forms.MessageBox.Show(segments.Count.ToString());
        }

        public string GetLocations() // I think this is just used for testing
        {
            
            int snakelength = segments.Count;
            string locations = "";
            for (int i = snakelength - 1; i >= 0; i--)
            {
                locations += "x = " + segments[i].X + " y = " + segments[i].Y + " IsHead = " + segments[i].IsHead.ToString() + "\r\n";
                

            }
            return locations;
        }

        private void endGame(methodOfDeath mod)
        {
            string death = "You've died.";
            if (mod == methodOfDeath.wall)
                death = "You've eaten the wall.";
            if (mod == methodOfDeath.snake)
                death = "Why are you biting yourself?";
            if (mod == methodOfDeath.explosion)
                death = "BOOOOOOM!";
            System.Windows.Forms.MessageBox.Show(death + "\r\nScore: " + Score);

            System.Threading.Thread.CurrentThread.Abort(); // TODO: I think this is bad practice
            
        }
        
    }
}
