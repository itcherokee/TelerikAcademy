namespace DocSystem
{
    using System.Collections.Generic;

    public class VideoDocument : MultimediaDocument
    {
        private const string KeyFrameRate = "framerate";

        /// <summary>
        /// Gets and sets the frame rate (fps) of the video content.
        /// </summary>
        protected byte? FrameRate { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case KeyFrameRate:
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
            output.Add(new KeyValuePair<string, object>(KeyFrameRate, this.FrameRate));
        }
    }
}