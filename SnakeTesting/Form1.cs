using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        Snake freddie;

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
                        
                        getUserInput();
                        doSnakeStuff();
                        drawBoard();

                        //TODO: wait X ms - time lapsed
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
        }
       
        private void doSnakeStuff() 
        {
            // limit speed of snake's movement here with timer or stopwatch
            // move snake

            // freddie.Move();
            
            // 
        }
        private void drawBoard() 
        {
            // freddie.GetLocations()
            // draw board
        }




    }
}
