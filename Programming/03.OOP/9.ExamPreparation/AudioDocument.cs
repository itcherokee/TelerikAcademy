using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class AudioDocument : MultimediaDocument
    {
        public double SampleRate { get; set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "samplerate":
                    this.SampleRate = double.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        }
    }
}
