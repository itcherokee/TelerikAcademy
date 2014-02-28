using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace GameLibrary
{
    public abstract class GamePanel : Panel
    {


        public static Size CalculateWindowBounds(Size gameRectangle, FormBorderStyle borderStyle)
        {
            Size s = gameRectangle;

            switch (borderStyle)
            {
                case FormBorderStyle.Sizable:
                    s.Width += SystemInformation.FrameBorderSize.Width * 2;
                    s.Height += SystemInformation.CaptionHeight + SystemInformation.FrameBorderSize.Height * 2;
                    break;
                case FormBorderStyle.FixedDialog:
                    s.Width += SystemInformation.FixedFrameBorderSize.Width * 2;
                    s.Height += SystemInformation.CaptionHeight + SystemInformation.FixedFrameBorderSize.Height * 2;
                    break;
            }

            return s;
        }


    }
}
