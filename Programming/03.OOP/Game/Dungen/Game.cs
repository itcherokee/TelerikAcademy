using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungen
{
    class Game
    {
        private Graphics device;
        private Bitmap surface;
        private Form form;
        private PictureBox pb;

        public Game(Form1 form, int width, int height)
        {
            Trace.WriteLine("Game class constructor");
            //set form properties 
            this.form = form;
            this.form.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.form.MaximizeBox = false;
            this.form.Size = new Size(width, height);
            //create a picturebox 
            this.pb = new PictureBox();
            pb.Parent = this.form;
            pb.Dock = DockStyle.Fill;
            
            pb.BackColor = Color.Black;
            //create graphics device 
            this.surface = new Bitmap(this.form.Size.Width, this.form.Size.Height);
            this.pb.Image = this.surface;
            this.device = Graphics.FromImage(this.surface);
        }

        ~Game()
        {
            Trace.WriteLine("Game class destructor");
            this.device.Dispose();
            this.surface.Dispose();
            this.pb.Dispose();
        }

        public Graphics Device
        {
            get
            {
                return this.device;
            }
        }

        public void Update()
        {
            //refresh the drawing surface 
            this.pb.Image = this.surface;
        }

        public Bitmap LoadBitmap(string file)
        {
            Bitmap bitmap = null;
            try
            {
                bitmap = new Bitmap(file);
            }
            catch (Exception)
            { }

            return bitmap;
        }
    }
}
