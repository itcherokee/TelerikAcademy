using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungen
{
    public partial class Form1 : Form
    {
        private Game game;
        private Image image;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(this, 500, 400);
            image = game.LoadBitmap("minion.jpg");
            game.Device.DrawImage(image, 100, 100, 100, 100);
            game.Update();
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            game = null;
        }


    }
}
