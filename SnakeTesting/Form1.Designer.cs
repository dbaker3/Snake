namespace Snake
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMoveRight = new System.Windows.Forms.Button();
            this.buttonAddSegment = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMoveRight
            // 
            this.buttonMoveRight.Location = new System.Drawing.Point(226, 274);
            this.buttonMoveRight.Name = "buttonMoveRight";
            this.buttonMoveRight.Size = new System.Drawing.Size(39, 23);
            this.buttonMoveRight.TabIndex = 0;
            this.buttonMoveRight.Text = "->";
            this.buttonMoveRight.UseVisualStyleBackColor = true;
            this.buttonMoveRight.Click += new System.EventHandler(this.buttonMoveRight_Click);
            // 
            // buttonAddSegment
            // 
            this.buttonAddSegment.Location = new System.Drawing.Point(181, 245);
            this.buttonAddSegment.Name = "buttonAddSegment";
            this.buttonAddSegment.Size = new System.Drawing.Size(84, 23);
            this.buttonAddSegment.TabIndex = 1;
            this.buttonAddSegment.Text = "Add Segment";
            this.buttonAddSegment.UseVisualStyleBackColor = true;
            this.buttonAddSegment.Click += new System.EventHandler(this.buttonAddSegment_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(181, 139);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 100);
            this.textBox1.TabIndex = 2;
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(181, 274);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(39, 23);
            this.buttonDown.TabIndex = 3;
            this.buttonDown.Text = "v";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(337, 320);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonAddSegment);
            this.Controls.Add(this.buttonMoveRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Snake";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMoveRight;
        private System.Windows.Forms.Button buttonAddSegment;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonDown;
    }
}

