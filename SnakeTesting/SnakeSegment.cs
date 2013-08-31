using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTesting
{
    // A segment of the snake. The snake is a list of segments.

    class SnakeSegment
    {

        public SnakeSegment(int x, int y, bool isHead = false, bool isNew = true)
        {
            this.X = x;
            this.Y = y;
            this.IsHead = isHead;
            this.IsNew = isNew; // if new, slither doesnt move segment until next slither
        }

        public int X { get; set; }
        public int Y { get; set; }

        public bool IsHead { get; set; }
        public bool IsNew { get; set; }

        public Utility.Movements Direction { get; set; }

        //public void AnnounceLocation()
        //{
        //    System.Windows.Forms.MessageBox.Show("x = " + X + "\ny =" + Y + "\nIsHead: " + IsHead.ToString());
            
        //}

    }
}
