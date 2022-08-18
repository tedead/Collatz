using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collatz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picture1.Image = null;
            var halfX = picture1.ClientRectangle.Width / 2;
            var halfY = picture1.ClientRectangle.Height / 2;
            int picture1Y = 0;

            for (int howManyTimes = 0; howManyTimes <= Convert.ToInt32(txtLoopCount.Text); howManyTimes++)
            {
                int seedRandomNumber = 0;

                Random seedRandom = new Random();
                seedRandomNumber = seedRandom.Next();

                listBox1.Items.Clear();
                listBox2.Items.Clear();

                int number = 0, temp = 0;
                Random rnd = new Random(seedRandomNumber);
                number = rnd.Next(1000);

                int dataSetSize = 1000;

                int[] dataSetArray = new int[dataSetSize];

                listBox1.Items.Add("Starting number: " + number);

                for (int x = 0; x < dataSetSize; x++)
                {
                    Application.DoEvents();

                    if (number % 2 == 0) //if even
                    {
                        dataSetArray[x] = number;
                        temp = number;
                        number = (number / 2);
                        listBox1.Items.Add("(" + temp + " / 2) = " + number);
                    }
                    else //number is odd
                    {
                        dataSetArray[x] = number;
                        temp = number;
                        number = (number * 3) + 1;
                        listBox1.Items.Add("(" + temp + " * 3) + 1 = " + number);
                    }

                    listBox1.SelectedIndex = x;
                }

                int y = 0;

                foreach (int i in dataSetArray)
                {
                    drawPoint(picture1Y, i);
                    //listBox2.Items.Add(i);
                    //listBox2.SelectedIndex = y;
                    //y++;
                }
                picture1Y += 5; //Move right on picture1 2 pixels
            }
        }

        public void drawPoint(int x, int y)
        {
            Graphics g = Graphics.FromHwnd(picture1.Handle);
            SolidBrush brush = new SolidBrush(Color.LimeGreen);
            Point dPoint = new Point(x, (picture1.Height - y));
            dPoint.X = dPoint.X - 2;
            dPoint.Y = dPoint.Y - 2;
            Rectangle rect = new Rectangle(dPoint, new Size(4, 4));
            g.FillRectangle(brush, rect);
            g.Dispose();
        }
    }
}
