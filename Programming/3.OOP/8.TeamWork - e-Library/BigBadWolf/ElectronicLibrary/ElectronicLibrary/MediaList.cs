using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class MediaList : IEnumerable
    {
        private List<Media> mediaList;

        public MediaList()
        {
            mediaList = new List<Media>();
        }

        public void GetMedia()
        {
            //TODO:
        }

        public void GetMediaByType()
        {
            //TODO:
        }

        public void GetMediaByBarcode()
        {
            //TODO:
        }

        public void AddMedia()
        {
            //TODO:
        }

        public void RemoveMedia()
        {
            //TODO:
        }



        public IEnumerator GetEnumerator()
        {
            return (this.mediaList as IEnumerable<Media>).GetEnumerator();
        }
    }
}
