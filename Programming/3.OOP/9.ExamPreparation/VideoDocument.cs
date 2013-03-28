using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public class VideoDocument : MultimediaDocument
    {
        public byte FrameRate { get; set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "framerate":
                    this.FrameRate = byte.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        }
    }
}
