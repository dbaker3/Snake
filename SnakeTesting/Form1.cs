using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeTesting
{
    public partial class Form1 : Form
    {
        Snake freddie;

        public Form1()
        {
            InitializeComponent();
            freddie = new Snake();

            while (true)    // Game Loop
            {
                //TODO: check time
                
                getUserInput();
                doSnakeStuff();
                drawBoard();

                //TODO: wait X ms - time lapsed
            }
                        
        }

        private void buttonMoveRight_Click(object sender, EventArgs e)
        {
            Utility.Movements direction = Utility.Movements.right;
            freddie.Slither(direction);

            textBox1.Text = freddie.GetLocations();
        }

        private void buttonAddSegment_Click(object sender, EventArgs e)
        {
            freddie.GrowSegment();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            Utility.Movements direction = Utility.Movements.down;
            freddie.Slither(direction);

            textBox1.Text = freddie.GetLocations();

           
        }


        private void getUserInput() 
        { 
            // get user input if any
            // set freddie.UserGivenDirection if input given
        }
       
        private void doSnakeStuff() 
        {
            // slither
            // 
        }
        private void drawBoard() 
        {
            // freddie.GetLocations()
            // draw board
        }




    }
}
