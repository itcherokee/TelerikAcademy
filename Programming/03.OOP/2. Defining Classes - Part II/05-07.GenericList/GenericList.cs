// Task 5:  Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
//          Keep the elements of the list in an array with fixed capacity which is given as parameter in the class 
//          constructor. Implement methods for adding element, accessing element by index, removing element by index, 
//          inserting element at given position, clearing the list, finding element by its value and ToString(). 
//          Check all input parameters to avoid accessing elements at invalid positions.
// Task 6:  Implement auto-grow functionality: when the internal array is full, create a new array of double size 
//          and move all elements to it.

namespace GenericListCollection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class GenericList<T> : IEnumerable<T>
    {
        private T[] elements;
        private int capacity;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the GenericList<T> class.
        /// </summary>
        /// <param name="capacity">Initial total size (capacity) of the list of T type elements.</param>
        public GenericList(int capacity = 4)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid initial capacity provided!");
            }

            this.elements = new T[capacity];
            this.capacity = capacity;
            this.Count = 0;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the current number of elements already in the list.
        /// </summary>
        /// <value>Number of elements</value>
        public int Count { get; private set; }

        /// <summary>
        /// Gets the capacity of the list (total amount of available slots for elements).
        /// </summary>
        /// <value>Total capacity.</value>
        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        /// <summary>
        /// Checks does list is full.
        /// </summary>
        public bool IsFull
        {
            get
            {
                return this.Count == this.Capacity;
            }
        }

        /// <summary>
        /// Checks does list is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return this.Count == 0;
            }
        }

        #endregion

        #region Indexer

        /// <summary>
        /// Gets or Sets an element value at certain position.
        /// </summary>
        /// <param name="index">Position index within the list.</param>
        /// <returns>Element of type T at index position.</returns>
        public T this[int index]
        {
            get
            {
                if (this.IsInRange(index))
                {
                    return this.elements[index];
                }

                throw new IndexOutOfRangeException("An attempt to access element at index which is not existing!");
            }

            set
            {
                if (this.IsInRange(index))
                {
                    this.elements[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("An attempt to access element at index which is not existing!");
                }
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Add element to the list
        /// </summary>
        /// <param name="element">Element to be added</param>
        public void Add(T element)
        {
            // Checks if list is full and resize it if necessary
            if (this.IsFull)
            {
                this.AutoGrow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        /// <summary>
        /// Insert element at specified position in the list
        /// /// </summary>
        /// <param name="element">Element to be added</param>
        /// <param name="index">Position where to be inserted</param>
        public void InsertAt(T element, int index)
        {
            // Checks if the index where to insert the element, is out of current boundaries of the existing elements.
            // Like List<> collection, if the index is the first free position (after last element) it insert element.
            if (index < 0 || index > this.Count || (this.IsEmpty && index != 0))
            {
                throw new IndexOutOfRangeException("The index provided is not within boundaries of the list!");
            }

            // Checks if list is full and resize it if necessary
            if (this.IsFull)
            {
                this.AutoGrow();
            }

            // Checks does the index is the first free element and if true add element, otherwise insert the element
            if (index == this.Count)
            {
                this.Add(element);
            }
            else
            {
                for (int i = this.Count; i > index; i--)
                {
                    this.elements[i] = this.elements[i - 1];
                }

                this.elements[index] = element;
                this.Count++;
            }
        }

        /// <summary>
        /// Removes an element from the specified position
        /// </summary>
        /// <param name="index">Position where is the element to be removed.</param>
        public void RemoveAt(int index)
        {
            if (this.IsEmpty || (index < 0 || index >= this.Count))
            {
                throw new IndexOutOfRangeException("Invalid index provided!");
            }

            for (int position = index + 1; position < this.Count; position++)
            {
                this.elements[position - 1] = this.elements[position];
            }

            this.Count--;

            // Clears (sets to default for element) the last element (no more used) after move of elements to the left wiht one
            Array.Clear(this.elements, this.Count, 1);
        }

        /// <summary>
        /// Finds element index by its value
        /// </summary>
        /// <param name="element">Element to be searched by it's content.</param>
        /// <returns>Index in the list of the element with searched content. If element is not found returns -1.</returns>
        public int Find(T element)
        {
            int index = -1;
            if (!this.IsEmpty)
            {
                index = Array.IndexOf<T>(this.elements, element);
            }

            return index;
        }

        /// <summary>
        /// Clears all items from list
        /// </summary>
        public void Clear()
        {
            if (!this.IsEmpty)
            {
                this.elements = new T[this.Capacity];
                this.Count = 0;
            }
        }

        /// <summary>
        /// Converts all elements in the list into special formated representation of System.string
        /// </summary>
        /// <returns>System.string</returns>
        public override string ToString()
        {
            if (!this.IsEmpty)
            {
                StringBuilder output = new StringBuilder();
                for (int i = 0; i < this.Count; i++)
                {
                    output.AppendLine(string.Format("Element[{0}] = {1}", i, this.elements[i].ToString()));
                }

                return output.ToString();
            }
            else
            {
                return "No elements in the array!";
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.Count > 0)
            {
                int index = 0;
                while (index < this.Count)
                {
                    yield return this.elements[index];
                    index++;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Automatically grow the list with it's double size after reaching the initial capacity
        /// </summary>
        private void AutoGrow()
        {
            this.capacity *= 2;
            T[] newListOfElements = new T[this.Capacity];
            Array.Copy(this.elements, newListOfElements, this.Count);
            this.elements = newListOfElements;
        }

        /// <summary>
        /// Checks does provided index is within the range of existing elements of the list.
        /// </summary>
        /// <param name="index">Index to be checked.</param>
        /// <returns>True - if index is within the boundaries of existing elements; False - if </returns>
        private bool IsInRange(int index)
        {
            return !this.IsEmpty && ((index >= 0) && (index < this.Count)) ? true : false;
        }

        #endregion
    }
}