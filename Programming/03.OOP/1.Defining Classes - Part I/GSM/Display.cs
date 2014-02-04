namespace Mobile
{
    using System.Text;

    public class Display
    {
        private readonly double size;
        private readonly ScreenResolution? resolution;
        private readonly ColorDepth colors;

        public Display()
            : this(null, null, null, null)
        {
        }

        public Display(double size, ColorDepth colors)
            : this(size, colors, null, null)
        {
        }

        public Display(double? size, ColorDepth? colors = null, int? width = null, int? height = null)
        {
            this.size = size.HasValue ? size.Value : 0.0;
            this.colors = colors.HasValue ? colors.Value : ColorDepth.Unknown;
            if (width.HasValue && height.HasValue)
            {
                this.resolution = new ScreenResolution() { Width = width.Value, Height = height.Value };
            }
            else
            {
                this.resolution = null;
            }
        }

        public string Size
        {
            get
            {
                if (this.size != 0.0f)
                {
                    return this.size.ToString();
                }
                else
                {
                    return "Unknown";
                }
            }
        }

        public ColorDepth Colors
        {
            get { return this.colors; }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("Size: {0}\"", this.Size));
            if (this.resolution.HasValue)
            {
                output.AppendLine(string.Format("Resolution: {0}x{1}", this.resolution.Value.Width, this.resolution.Value.Height));
            }
            else
            {
                output.AppendLine(string.Format("Resolution: {0}", "<unknown>"));
            }

            output.Append(string.Format("Color depth: {0}", this.Colors));
            return output.ToString();
        }

        internal struct ScreenResolution
        {
            internal int Width;
            internal int Height;
        }
    }
}
