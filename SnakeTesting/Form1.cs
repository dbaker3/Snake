using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Snake
{
    public partial class Form1 : Form
    {
        Snake freddie;
        Graphics graph;
        Bitmap bmSnakeSeg = new Bitmap("../../bmSnakeSeg.png");
        Bitmap bmBackColor = new Bitmap("../../bmBackColor.png");
        Bitmap bmFood = new Bitmap("../../bmFood.png");
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        
        const int BITMAPOFFSET = 10; //pixels
        int SnakeSpeedDelay = 100; //milliseconds

        public Form1()
        {
            InitializeComponent();
            freddie = new Snake();
            graph = CreateGraphics();

            // Run game loop in new thread so form stays responsive
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = false;
            bw.DoWork += new DoWorkEventHandler(
            delegate(object o, DoWorkEventArgs args)
                {
                    System.Threading.Thread.Sleep(100); // Gives form time to draw before starting game loop

                    while (true)    // Game Loop
                    {
                        // Start stopwatch time loop
                        sw.Start();

                        doSnakeStuff();
                        drawBoard();
                        
                        // Wait in order to slow animation speed
                        sw.Stop();
                        System.Threading.Thread.Sleep(SnakeSpeedDelay - (int)sw.ElapsedMilliseconds);
                        sw.Reset();                
                    }
                });
            
            bw.RunWorkerAsync();            
           
        }
            
        private void doSnakeStuff() 
        {
            freddie.Move();
        }

        private void drawBoard() 
        {
            // snake
            graph.DrawImage(bmSnakeSeg, freddie.SegmentToDraw.X * BITMAPOFFSET, freddie.SegmentToDraw.Y * BITMAPOFFSET);
            if (freddie.SegmentToErase != null)
                graph.DrawImage(bmBackColor, freddie.SegmentToErase.X * BITMAPOFFSET, freddie.SegmentToErase.Y * BITMAPOFFSET);    

            // food
            graph.DrawImage(bmFood, Board.FoodX * BITMAPOFFSET, Board.FoodY * BITMAPOFFSET);
        }   

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    freddie.Direction = Utility.Movements.right;
                    break;
                case Keys.Left:
                    freddie.Direction = Utility.Movements.left;
                    break;
                case Keys.Up:
                    freddie.Direction = Utility.Movements.up;
                    break;
                case Keys.Down:
                    freddie.Direction = Utility.Movements.down;
                    break;

                // Cheats
                case Keys.Subtract:
                    if (SnakeSpeedDelay <= 200)
                        SnakeSpeedDelay += 25;
                    break;
                case Keys.Add:
                    if (SnakeSpeedDelay >= 50)
                        SnakeSpeedDelay -= 25;
                    break;
                
                default:
                    break;
            }
        }



    }
}
