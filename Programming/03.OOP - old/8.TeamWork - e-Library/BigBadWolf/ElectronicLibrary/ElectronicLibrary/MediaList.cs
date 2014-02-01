using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class MediaList : IEnumerable
    {
        #region Event declaration to be fired when there is a change in the list of Media

        public delegate void MediaChangeEventHandler(IEnumerable<Media> list);

        public event MediaChangeEventHandler RecordMediaHasBeenChanged;

        // fires the event in case of records change
        protected virtual void OnChange()
        {
            if (RecordMediaHasBeenChanged != null)
            {
                RecordMediaHasBeenChanged(medias);
            }
        }

        #endregion

        private List<Media> medias;

        public MediaList()
        {
            medias = new List<Media>();
        }

        private IEnumerable<Media> Search(Media mediaSource)
        {
            var query = from media in medias
                        where media.Details.Barcode == mediaSource.Details.Barcode
                        select media;
            return query;
        }

        public IEnumerable<Media> SearchByBarcode(long barcode)
        {
            var query = from media in medias
                        where media.Details.Barcode == barcode
                        select media;
            return query;
        }

        public void Add(Media media)
        {
            if (!Search(media).Any())
            {
                this.medias.Add(media);
                OnChange();
            }
            else
            {
                throw new LibraryException.MediaExistException("The media already exist in the system!");
            }
        }

        public void Remove(Media media)
        {
            if (this.medias.Exists((x) => x.Equals(media)))
            {
                this.medias.Remove(media);
                OnChange();
            }
            else
            {
                throw new LibraryException.NonExistingMediaException("There is no such media in the system!");
            }
        }

         public int TotalNumberOfMedia()
        {
            int number = medias.Count();
            return number;
        }

        public int TotalNumberOfBooks()
        {
            int number = medias.Count(media => media.GetType().Name == "Book");
            return number;
        }

        public int TotalNumberOfNewspapers()
        {
            int number = medias.Count(media => media.GetType().Name == "Newspaper");
            return number;
        }

        public int TotalNumberOfMagazines()
        {
            int number = medias.Count(media => media.GetType().Name == "Magazine");
            return number;
        }

        public int TotalNumberOfMovies()
        {
            int number = medias.Count(media => media.GetType().Name == "Movie");
            return number;
        }

        // Count different medias based on their type
        public int CountByMediaType(MediaType mediaType)
        {
            return medias.Count((x) => x.Details.Type == mediaType);
        }

        // Convert Media object to List<Media> list
        public List<Media> GetMedias()
        {
            return medias.ToList();
        }

        public IEnumerator GetEnumerator()
        {
            return (this.medias as IEnumerable<Media>).GetEnumerator();
        }
    }
}
