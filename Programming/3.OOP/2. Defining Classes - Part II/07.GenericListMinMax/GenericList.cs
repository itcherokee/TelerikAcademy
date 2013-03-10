// Create generic methods Min<T>() and Max<T>() for finding the minimal 
// and maximal element in the  GenericList<T>. You may need to add a generic constraints for the type T.

namespace GenericClass
{
    using System;
    using System.Text;

    public class GenericList<T>
    {
        #region Fields

        private T[] listArray;
        private T[] listArrayTemp;
        private int? currentSize;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the GenericList<T> class with custom capacity.
        /// </summary>
        /// <param name="size">Initial total size (capacity) of the list</param>
        public GenericList(int size = 4)
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

        #endregion

        #region Indexer

        /// <summary>
        /// Indexer of the list
        /// </summary>
        /// <param name="index">index</param>
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
        /// Returns true if index is in range of existing elements in the list
        /// </summary>
        private bool IsInRange(int index)
        {
            return ((index >= 0) && (index < this.CurrentSize)) ? true : false;
        }

        /// <summary>
        /// Returns the minimal element in the list. Type need to inherit IComparable interface in order elements to be comparable
        /// </summary>
        /// <returns>Element of type holded in the list which is with minimal value</returns>
        public T Min<T>() where T : IComparable, IComparable<T>
        {
            if (!this.IsEmpty)
            {
                dynamic smallestElement = this.listArray[0];
                for (int i = 1; i < this.CurrentSize; i++)
                {
                    if (smallestElement > this.listArray[i])
                    {
                        smallestElement = this.listArray[i];
                    }
                }

                return smallestElement;
            }
            else
            {
                throw new IndexOutOfRangeException("List is empty!");
            }
        }

        /// <summary>
        /// Returns the maximal element in the list. Type need to inherit IComparable interface in order elements to be comparable
        /// </summary>
        /// <returns>Element of type holded in the list which is with maximal value</returns>
        public T Max<T>() where T : IComparable, IComparable<T>
        {
            if (!this.IsEmpty)
            {
                dynamic biggestElement = this.listArray[0];
                for (int i = 1; i < this.CurrentSize; i++)
                {
                    if (biggestElement < this.listArray[i])
                    {
                        biggestElement = this.listArray[i];
                    }
                }

                return biggestElement;
            }
            else
            {
                throw new IndexOutOfRangeException("List is empty!");
            }
        }

        /// <summary>
        /// Automatically grow the list with it's double size after reaching the initial capacity
        /// </summary>
        private void AutoGrow()
        {
            this.listArrayTemp = new T[this.TotalSize * 2];
            Array.Copy(this.listArray, this.listArrayTemp, this.TotalSize);
            this.listArray = this.listArrayTemp;

            // free temp array allocated memory (cut the reference in order GC to handle it 
            this.listArrayTemp = null;

            // enlarge the TotalSize property to hold new capasity of list
            // due to automatic property TotalSize, also CurrentSize is enlarged ( why??? - unknown) 
            // and we need to keep the original value and reassign it
            int? tempCurrentSize = this.CurrentSize.Value;
            this.TotalSize = this.listArray.Length;
            this.CurrentSize = tempCurrentSize.Value;
        }

        /// <summary>
        /// Add element to the list
        /// </summary>
        /// <param name="element">Element to be added</param>
        public void Add(T element)
        {
            // checks if list is full and first enlarge it if it is the case, before adding the new element
            if (this.IsFull)
            {
                this.AutoGrow();
            }

            this.listArray[this.CurrentSize.Value] = element;
            this.CurrentSize = this.CurrentSize + 1;
        }

        /// <summary>
        /// Insert element at specified position in the list
        /// /// </summary>
        /// <param name="element">Element to be added</param>
        /// <param name="index">Position where to be inserted</param>
        public void InsertAt(T element, int index)
        {
            // checks if the index where to be inserted the element is after current last element (more than 1 position)
            if (!(index > this.CurrentSize))
            {
                // checks if list is full and if it the case, enlarges it before inserting the element
                if (this.IsFull)
                {
                    this.AutoGrow();
                }

                // check does the index is the first free element and if true adds the element, otherwise insert the element
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
