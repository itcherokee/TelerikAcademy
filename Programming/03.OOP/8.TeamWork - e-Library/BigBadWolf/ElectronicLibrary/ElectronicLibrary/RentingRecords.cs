using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class RentingRecords
    {
        public RentingRecords()
        {
            record = new SortedList<string, Status>();
        }

        public struct Status
        {
            public long barcode;
            public string operation;
        }

        public SortedList<string, Status> record;

        public void Add(Person client, Media media, string operation)
        {
            Status details = new Status();
            details.barcode = media.Details.Barcode;
            details.operation = operation;
            record.Add(client.PersonalID, details);
        }


        public void RemoveTask(Person client, Media media, string operation)
        { 
            // TODO: to be developed
        }

    }
}
