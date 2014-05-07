namespace KpkPracticalExam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface ICatalog
    {
        void Add(IContent content);

        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        int Update(string oldUrl, string newUrl);
    }
}
