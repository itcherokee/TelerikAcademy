using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BalkanSuperHero;
using BalkanSuperHero.Enumerations;
using BalkanSuperHero.GameObjects;
using BalkanSuperHero.Interfaces;

namespace BalkanSuperHeroRenderer
{
    public partial class Form1 : Form, IRenderer, IInputControl
    {
        private Bitmap image;
        private Graphics device;
        private PictureBox area;
        private Game game;

        public Form1()
        {
            InitializeComponent();

        }



        public object Device
        {
            get
            {
                return this.area;
            }
        }

        public void InitializeRenderer(int width, int height)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(width + 6, height + 28);
            this.area = new PictureBox();
            this.area.Parent = this;
            this.area.Dock = DockStyle.Fill;
            this.area.Width = width;
            this.area.Height = height;
            this.area.Focus();
            this.area.Image = LoadBackground("grass.bmp");
            this.device = Graphics.FromImage(area.Image);

        }

        public void ProcessForDrawing(IEnumerable<Sprite> objects)
        {
            throw new NotImplementedException();
        }

        public void UpdateAll(IEnumerable<Sprite> objects)
        {
            //throw new NotImplementedException();
        }

        public InputType InputControl { get; private set; }

        public void InitializeInputControls(InputType inputType)
        {
            this.InputControl = inputType;
            if (inputType.HasFlag(InputType.Mouse))
            {
                this.MouseClick += new MouseEventHandler(Action);
            }

            if (inputType.HasFlag(InputType.Keyboard))
            {
                this.KeyDown += new KeyEventHandler(Action);
            }
        }

        public void Action(object sender, EventArgs e)
        {
            switch (this.InputControl)
            {
                case InputType.Keyboard:
                    var key = (e as KeyEventArgs).KeyCode;
                    switch (key)
                    {
                        case Keys.Up:

                            break;
                        case Keys.Down:

                            break;
                        case Keys.Left:

                            break;
                        case Keys.Right:

                            break;
                    }
                    break;
                case InputType.Mouse:

                    break;
            }
        }

        public void ProcessInput()
        {
            Application.DoEvents();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private Bitmap LoadBackground(string picture)
        {
            Bitmap image = null;
            try
            {
                image = new Bitmap(picture);
            }
            catch (Exception)
            {
                throw;
            }

            return image;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.game = new Game(this, this);
            this.game.Start();
        }
    }
}
