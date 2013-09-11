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
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        public Form1()
        {
            InitializeComponent();
            freddie = new Snake();


            


            // Run game loop in new thread so form stays responsive
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = false;
            bw.DoWork += new DoWorkEventHandler(
            delegate(object o, DoWorkEventArgs args)
                {
                    while (true)    // Game Loop
                    {
                        //TODO: check time
                        sw.Start();

                        getUserInput();
                        doSnakeStuff();
                        drawBoard();
                        
                        //// graphics testing
                        //graph = CreateGraphics();
                        //graph.DrawImage(bmSnakeSeg, 1, 1);


                        //TODO: wait X ms - time lapsed
                        sw.Stop();
                        

                        //System.Threading.Thread.Sleep(150 - (int)sw.ElapsedMilliseconds);
                        MessageBox.Show(sw.ElapsedMilliseconds.ToString());

                        sw.Reset();
                        
                    }
                });
            bw.RunWorkerAsync();

                        
        }

        private void buttonMoveRight_Click(object sender, EventArgs e)
        {
            //Utility.Movements direction = Utility.Movements.right;
            //freddie.Move(direction);

            freddie.Direction = Utility.Movements.right;
            freddie.Move();

            textBox1.Text = freddie.GetLocations();
        }

        private void buttonAddSegment_Click(object sender, EventArgs e)
        {
            freddie.GrowSegment();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            //Utility.Movements direction = Utility.Movements.down;
            //freddie.Move(direction);

            freddie.Direction = Utility.Movements.down;
            freddie.Move();

            textBox1.Text = freddie.GetLocations();
            
           
        }


        private void getUserInput() 
        { 
            // get user input if any
            // set freddie.Direction if given
            // otherwise freddie will continue in last assigned direction

            if (Keyboard.IsKeyDown(Key.Down))
                freddie.Direction = Utility.Movements.down;

        }
       
        private void doSnakeStuff() 
        {
            // limit speed of snake's movement here with timer or stopwatch
            // move snake

            freddie.Move();
            
            // 
        }

        private void drawBoard() 
        {
            // TODO: draw rectangles instead of loading bitmap?
            graph = CreateGraphics();
            //Bitmap bmSnakeSeg = new Bitmap("../../bmSnakeSeg.png");

            Board.PositionStates state = Board.PositionStates.empty;

            // TODO: need to query snake for location of each segment instead of looping through board.
            // Get state of each area of board
            for (int x = 0; x < Board.PlayfieldWidth; x++)
            {
                for (int y = 0; y < Board.PlayfieldHeight; y++)
                {
                    // set state on form's board
                    state = Board.GetPositionStatus(x, y);

                    // draw segments
                    //if (Board.GetPositionStatus(x,y) == Board.PositionStates.snake)
                        graph.DrawImage(bmSnakeSeg, x * 10, y * 10);
                        //graph.DrawRectangle(new Pen(Color.White), x * 10, y * 10, 10, 10);
                    
                }
            }
             
            // draw board on form
            
        }




    }
}
