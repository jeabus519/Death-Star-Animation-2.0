using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Death_Star_Animation_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void drawDeathStar()
        {
            Graphics formGraphics = this.CreateGraphics();
            Pen drawPen = new Pen(Color.White, 5);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            formGraphics.DrawEllipse(drawPen, 80, 150, 200, 200);

            formGraphics.DrawLine(drawPen, 180, 150, 180, 250);

            formGraphics.FillEllipse(drawBrush, 180 - 30 /2, 250 - 30 / 2, 30, 30);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = null;
            Refresh();

            Graphics formGraphics = this.CreateGraphics();
            Pen drawPen = new Pen(Color.White, 5);
            SolidBrush drawBrush = new SolidBrush(Color.White);
            SolidBrush bombBrush = new SolidBrush(Color.White);
            bombBrush.Color = Color.FromArgb(255, 255, 0, 0);
            Font titleFont = new Font("Consolas", 20);
            Font bodyFont = new Font("Consolas", 15);

            SoundPlayer alertPlayer = new SoundPlayer(Properties.Resources.alert);
            alertPlayer.Play();

            //intro paragraph
            formGraphics.DrawString("Death Star Attack Plan", titleFont, drawBrush, 10, 25);
            formGraphics.DrawString("Step 1: Fly to deathstar \nStep 2: Torpedo it \nStep 3: Celebrate", bodyFont, drawBrush, 25, 75);

            Thread.Sleep(5000);

            //draw the ship flying over the death star
            for (int x1 = this.Width + 10; x1 >= 165; x1--)
            {
                formGraphics.Clear(Color.Black);
                drawDeathStar();
                formGraphics.FillRectangle(drawBrush, x1, 100, 30, 10); //draw ship
                Thread.Sleep(5);
            }

            //draw the ship leaving and the bomb traveling down the shaft
            int y2 = 100;
            for (int y = 100; y <= 250 - 20 / 2; y++)
            {
                formGraphics.Clear(Color.Black);
                drawDeathStar();
                formGraphics.FillEllipse(bombBrush, 170, y, 20, 20); //draw bomb
                formGraphics.FillRectangle(drawBrush, 164, y2, 30, 10); //draw ship
                y2--;
                Thread.Sleep(5);
            }

            //draw the blast
            SoundPlayer player = new SoundPlayer(Properties.Resources.Grenade_SoundBible_com_2124844747);
            player.Play();
            for (int radius = 10; radius <= 240; radius++)
            {
                formGraphics.Clear(Color.Black);
                drawDeathStar();
                formGraphics.FillEllipse(bombBrush, 180 - radius / 2, 251 - radius / 2, radius, radius); //draw blast
                Thread.Sleep(5);
            }

            //make the deathstar dissapear and the blast fade away
            int radius1 = 241;
            for (int x3 = 255; x3 >= 0; x3--)
            {
                formGraphics.Clear(Color.Black);
                bombBrush.Color = Color.FromArgb(x3, 255, 0, 0);
                formGraphics.FillEllipse(bombBrush, 180 - radius1 / 2, 251 - radius1 / 2, radius1, radius1); //draw blast
                radius1++;
                Thread.Sleep(2);
            }
        }
    }
}
