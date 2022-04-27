using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacmanny_1
{
    public partial class Form1 : Form
    {

        // Variables

        bool goup;
        bool godown;
        bool goleft;
        bool goright;

        int speed = 5;


        // Variables for Ghost 1 and 2

        int ghost1 = 8;
        int ghost2 = 8;


        // Variables for Ghost 3

        int ghost3x = 8;
        int ghost3y = 8;

        int score = 0;

        // no more Variables


        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            label1.Text = "Score: " + score; // scoreboard shown on screen

            // Player Movement
            if (goleft)
            {
                pacman.Left -= speed;
                // Moving to the left 
            }
            if (goright)
            {
                pacman.Left += speed;
                // Moving to the right
            }
            if (goup)
            {
                pacman.Top -= speed;
                // Moving up
            }

            if (godown)
            {
                pacman.Top += speed;
                // Moving down
            }           

            // Ghosts Movement and Walls
            redGhost.Left += ghost1;
            yellowGhost.Left += ghost2;

            // When the red Ghost hits pictureBox4, the speed gets reversed
            if (redGhost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                ghost1 = -ghost1;
            }
            // When the red ghost hits pictureBox2, the speed gets reversed
            else if (redGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                ghost1 = -ghost1;
            }
            // When the yellow Ghost hits pictureBox1, the speed gets reversed
            if (yellowGhost.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                ghost2 = -ghost2;
            }
            // When the yellow Ghost hits pictureBox3, the speed gets reversed
            else if (yellowGhost.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                ghost2 = -ghost2;
            }           

            // for loop to check walls, ghosts and points
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "wall" || x.Tag == "ghost")
                {
                    // Check for Player hitting a wall or ghost to end the game
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds) || score == 30)
                    {
                        pacman.Left = 0;
                        pacman.Top = 25;
                        label2.Text = "GAME OVER";
                        label2.Visible = true;
                        timer1.Stop();

                    }
                }
                if (x is PictureBox && x.Tag == "coin")
                {
                    // Check for Player hitting coin PictureBox, if so then add it
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x); // remove that point
                        score++; // add to the score
                    }
                }
            }

            // Pink Ghost Movement
            pinkGhost.Left += ghost3x;
            pinkGhost.Top += ghost3y;

            if (pinkGhost.Left < 1 ||
                pinkGhost.Left + pinkGhost.Width > ClientSize.Width - 2 ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox4.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox3.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox1.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
                )
            {
                ghost3x = -ghost3x;
            }
            if (pinkGhost.Top < 1 || pinkGhost.Top + pinkGhost.Height > ClientSize.Height - 2)
            {
                ghost3y = -ghost3y;
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                pacman.Image = Properties.Resources.c_users_admin_desktop_images_pac_man_images_mooic_3;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = true;

                pacman.Image = Properties.Resources.c_users_admin_desktop_images_pac_man_images_mooic_2;
            }
            if (e.KeyCode == Keys.Up)
            {

                goup = true;
                pacman.Image = Properties.Resources.c_users_admin_desktop_images_pac_man_images_mooic;
            }
            if (e.KeyCode == Keys.Down)
            {

                godown = true;
                pacman.Image = Properties.Resources.c_users_admin_desktop_images_pac_man_images_mooic_1;
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
