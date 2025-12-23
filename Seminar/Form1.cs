using System;
using System.Drawing;
using System.Windows.Forms;

namespace Seminar
{
    public partial class Form1 : Form
    {
        int speed = 10;
        int score = 0;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Score: 0";

            panel1.TabStop = false;
            pictureBox1.TabStop = false;
            pictureBox2.TabStop = false;
            button1.TabStop = false;

            NewGame();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.A || keyData == Keys.Left)
                pictureBox1.Left -= speed;
            else if (keyData == Keys.D || keyData == Keys.Right)
                pictureBox1.Left += speed;
            else if (keyData == Keys.W || keyData == Keys.Up)
                pictureBox1.Top -= speed;
            else if (keyData == Keys.S || keyData == Keys.Down)
                pictureBox1.Top += speed;

            CheckPanelBorder();
            CheckCollision();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        void CheckPanelBorder()
        {
            if (pictureBox1.Left < 0 ||
                pictureBox1.Top < 0 ||
                pictureBox1.Right > panel1.Width ||
                pictureBox1.Bottom > panel1.Height)
            {
                MessageBox.Show("Panelin borderinə dəydin! Uduzdun!");
                NewGame();
            }
        }

        void CheckCollision()
        {
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                score++;
                label1.Text = "Score: " + score;
                MoveBone();
            }
        }

        void MoveBone()
        {
            pictureBox2.Left = rnd.Next(0, panel1.Width - pictureBox2.Width);
            pictureBox2.Top = rnd.Next(0, panel1.Height - pictureBox2.Height);
        }

        void NewGame()
        {
            score = 0;
            label1.Text = "Score: 0";
            pictureBox1.Left = 50;
            pictureBox1.Top = 50;
            MoveBone();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewGame();
        }
    }
}