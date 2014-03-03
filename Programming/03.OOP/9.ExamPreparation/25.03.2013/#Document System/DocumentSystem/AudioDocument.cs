namespace DocSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AudioDocument : MultimediaDocument
    {
        private const string KeySampleRate = "samplerate";

        /// <summary>
        /// Gets and sets the sample rate (in Hz) of the audio content.
        /// </summary>
        protected int? SampleRate { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case KeySampleRate:
                    this.SampleRate = int.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>(KeySampleRate, this.SampleRate));
        }
    }
}