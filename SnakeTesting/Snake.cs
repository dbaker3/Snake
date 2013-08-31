using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTesting
{
    class Snake
    {
        List<SnakeSegment> segments;

        public Utility.Movements UserGivenDirection { set; private get; }

        public Snake()
        {
            UserGivenDirection = Utility.Movements.right;
            segments = new List<SnakeSegment>();
            segments.Add(new SnakeSegment(0, 2, true, false)); // snake head
            segments.Add(new SnakeSegment(0, 1, false, false));
            segments.Add(new SnakeSegment(0, 0, false, false));
        }
        
        public void Slither(Utility.Movements direction = Utility.Movements.same)
        {
            int snakeLength = segments.Count;
            for (int i = snakeLength - 1; i >= 0; i--) // Move each segment starting at END OF TAIL
            {
                if (!segments[i].IsNew) // move it if not new
                {
                    //segments[i].AnnounceLocation();
                    if (segments[i].IsHead)
                    {
                        if (direction == Utility.Movements.same)
                            direction = this.UserGivenDirection; // use previous direction

                        this.UserGivenDirection = direction; // store new direction

                        // TODO: Do move
                        switch (direction)
                        {
                            case Utility.Movements.up:
                                // TODO: boundary check
                                Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.empty);
                                segments[i].X = segments[i].X;
                                segments[i].Y -= 1;
                                Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.snake);
                                break;
                            case Utility.Movements.down:
                                // TODO: boundary check
                                Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.empty);
                                segments[i].X = segments[i].X;
                                segments[i].Y += 1;
                                Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.snake);
                                break;
                            case Utility.Movements.left:
                                // TODO: boundary check
                                Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.empty);
                                segments[i].X -= 1;
                                segments[i].Y = segments[i].Y;
                                Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.snake);
                                break;
                            case Utility.Movements.right:
                                // TODO: boundary check
                                Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.empty);
                                segments[i].X += 1;
                                segments[i].Y = segments[i].Y;
                                Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.snake);
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
                        Board.SetPositionStatus(segments[i].X, segments[i].Y, Board.PositionStates.snake);
                    }

                }
                else // was new so it didn't move - mark it not new for next time
                {
                    segments[i].IsNew = false;
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
            // don't move it on next slither (implemented in slither method)
            //System.Windows.Forms.MessageBox.Show(segments.Count.ToString());
        }

        public string GetLocations() // TODO: this will eventually need to return usable values so that the snake can be drawn. Right now it just returns a string to be shown in a textbox.
        {
            
            int snakelength = segments.Count;
            string locations = "";
            for (int i = snakelength - 1; i >= 0; i--)
            {
                locations += "x = " + segments[i].X + " y = " + segments[i].Y + " IsHead = " + segments[i].IsHead.ToString() + "\r\n";


            }
            return locations;
        }
        
    }
}
