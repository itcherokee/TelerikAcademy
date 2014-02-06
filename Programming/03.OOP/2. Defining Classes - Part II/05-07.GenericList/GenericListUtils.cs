// Таск 7:  Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the 
//          GenericList<T>. You may need to add a generic constraints for the type T.

namespace GenericListCollection
{
    using System;

    public static class GenericListUtils
    {
        /// <summary>
        /// Returns the minimal element in the list. Type need to inherit IComparable interface in order 
        /// elements to be comparable.
        /// </summary>
        /// <returns>Element of type holded in the list which is with minimal value.</returns>
        public static T Min<T>(this GenericList<T> elements) where T : IComparable, IComparable<T>
        {
            if (!elements.IsEmpty)
            {
                var smallestElement = elements[0];
                for (int i = 1; i < elements.Count; i++)
                {
                    if (elements[i].CompareTo(smallestElement) < 0)
                    {
                        smallestElement = elements[i];
                    }
                }

                return smallestElement;
            }

            throw new IndexOutOfRangeException("List is empty!");
        }

        /// <summary>
        /// Returns the maximal element in the list. Type need to inherit IComparable interface in order elements to be comparable
        /// </summary>
        /// <returns>Element of type holded in the list which is with maximal value</returns>
        public static T Max<T>(this GenericList<T> elements) where T : IComparable, IComparable<T>
        {
            if (!elements.IsEmpty)
            {
                T biggestElement = elements[0];
                for (int i = 1; i < elements.Count; i++)
                {
                    if (elements[i].CompareTo(biggestElement) > 0)
                    {
                        biggestElement = elements[i];
                    }
                }

                return biggestElement;
            }

            throw new IndexOutOfRangeException("List is empty!");
        }
    }
}
