// Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
// Keep the elements of the list in an array with fixed capacity which is given as parameter in
// the class constructor. Implement methods for adding element, accessing element by index, 
// removing element by index, inserting element at given position, clearing the list, finding 
// element by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.

namespace GenericClass
{
    using System;
    using System.Text;

    public class GenericList<T> 
    {
        #region Fields
        private T[] listArray;
        private int? currentSize;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the GenericList<T> class.
        /// </summary>
        /// <param name="size">Initial total size (capacity) of the list of T type elements</param>
        public GenericList(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("There must be at least 1 empty position for element in the list!");
            }

            this.listArray = new T[size];
            this.TotalSize = size;
            this.CurrentSize = 0;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the current number of elements already in the list.
        /// </summary>
        /// <value>Number of elements</value>
        public int? CurrentSize
        {
            get
            {
                return this.currentSize ?? this.TotalSize;
            }

            private set
            {
                this.currentSize = value == this.TotalSize ? null : value;
            }
        }

        /// <summary>
        /// Gets the total size (capacity) of the list.
        /// </summary>
        /// <value>Total capacity</value>
        public int TotalSize { get; private set; }

        /// <summary>
        /// Returns true if list is full
        /// </summary>
        public bool IsFull
        {
            get
            {
                return this.currentSize == null;
            }
        }
        
        /// <summary>
        /// Returns true if list is empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return this.CurrentSize.Value == 0;
            }
        }

        /// <summary>
        /// Returns true if index is in range of existing elements in the list
        /// </summary>
        private bool IsInRange(int index)
        {
            return ((index >= 0) && (index < this.CurrentSize)) ? true : false;
        }
        #endregion

        #region Indexer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Element of type T at index position</returns>
        public T this[int index]
        {
            get
            {
                return this.listArray[index];
            }

            set
            {
                if (this.IsInRange(index))
                {
                    this.listArray[index] = value;
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
            if (!this.IsFull)
            {
                this.listArray[this.CurrentSize.Value] = element;
                this.CurrentSize = this.CurrentSize + 1;
            }
            else
            {
                throw new IndexOutOfRangeException("No more space in the list!");
            }
        }

        /// <summary>
        /// Insert element at specified position in the list
        /// /// </summary>
        /// <param name="element">Element to be added</param>
        /// <param name="index">Position where to be inserted</param>
        public void InsertAt(T element, int index)
        {
            // checks if list is full and rise exception if true
            if (!this.IsFull)
            {
                // checks if the index where to be inserted the element is after current last element (more than 1 position)
                if (!(index > this.CurrentSize))
                {
                    // check does the index is the first free element and if true add element, otherwise insert the element
                    if (index == this.CurrentSize)
                    {
                        this.Add(element);
                    }
                    else
                    {
                        for (int i = this.CurrentSize.Value; i > index; i--)
                        {
                            this.listArray[i] = this.listArray[i - 1];
                        }

                        this.listArray[index] = element;
                        this.CurrentSize++;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("The index provided is far after first free element!");
                }
            }
            else
            {
                throw new IndexOutOfRangeException("No more space in the list!");
            }
        }

        /// <summary>
        /// Removes an element from the specified position
        /// </summary>
        /// <param name="index">Position where is the element to be removed</param>
        public void RemoveAt(int index)
        {
            if (!this.IsEmpty)
            {
                if (index >= 0 && index <= this.CurrentSize.Value)
                {
                    for (int i = index + 1; i < this.CurrentSize; i++)
                    {
                        this.listArray[i - 1] = this.listArray[i];
                    }

                    this.CurrentSize--;
                    
                    // Clears (sets to default for element) the last element (no more used) after move of elements to the left wiht one
                    Array.Clear(this.listArray, this.CurrentSize.Value, 1);
                }
                else
                {
                    throw new IndexOutOfRangeException("There is no element with provided index!");
                }
            }
            else
            {
                throw new IndexOutOfRangeException("List is empty!");
            }
        }

        /// <summary>
        /// Finds element index by its value
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public int Find(T element)
        {
            if (!this.IsEmpty)
            {
                return Array.IndexOf<T>(this.listArray, element);
            }
            else
            {
                throw new IndexOutOfRangeException("List is empty!");
            }
        }

        /// <summary>
        /// Clears all items from list
        /// </summary>
        public void Clear()
        {
            if (!this.IsEmpty)
            {
                this.listArray = new T[this.TotalSize];
                this.CurrentSize = 0;
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
                for (int i = 0; i < this.CurrentSize; i++)
                {
                    output.Append(string.Format("Element[{0}] = {1}\n", i, this.listArray[i].ToString()));
                }

                return output.ToString();
            }
            else
            {
                return "No elements in the array!";
            }
        }
        #endregion
    }
}
