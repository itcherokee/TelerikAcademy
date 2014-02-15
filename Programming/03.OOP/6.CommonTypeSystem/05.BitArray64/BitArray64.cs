// Task 5:  Define a class BitArray64 to hold 64 bit values inside an ulong value. Implement IEnumerable<int> 
//          and Equals(…), GetHashCode(), [], == and !=.

namespace MyBitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BitArray64 : IEnumerable<int>
    {
        private ulong bits;

        /// <summary>
        /// Instantiates an object of type BitArray64.
        /// </summary>
        /// <param name="initialValue">Initial state of the bits represented as ulong number.</param>
        public BitArray64(ulong initialValue = 0)
        {
            this.bits = initialValue;
        }

        public ulong Value
        {
            get
            {
                return this.bits;
            }
        }

        /// <summary>
        /// Index access to get or set separate bits from the bit's array.
        /// </summary>
        /// <param name="index">Index of the bit to be accessed.</param>
        /// <returns>Value of the bit at the index possition - 1 or 0.</returns>
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index <= 63)
                {
                    return (this.bits & 1ul << index) >> index == 1 ? 1 : 0;
                }

                throw new IndexOutOfRangeException("Invalid bit index specified!");
            }

            set
            {
                if ((index >= 0 && index <= 63) && (value == 1 || value == 0))
                {
                    ulong mask = 1ul << index;
                    switch (value)
                    {
                        case 1:
                            this.bits = this.bits | mask;
                            break;
                        case 0:
                            this.bits = this.bits & ~mask;
                            break;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid bit index or bit value specified!");
                }
            }
        }

        /// <summary>
        /// Compares two instances of BitArray64 for reference equality as they are not immutable 
        /// in order to compare them as value.
        /// </summary>
        public static bool operator ==(BitArray64 numberOne, BitArray64 numberTwo)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(numberOne, numberTwo))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)numberOne == null) || ((object)numberTwo == null))
            {
                return false;
            }

            // Return true if the bits match:
            return numberOne.bits == numberTwo.bits;
        }

        public static bool operator !=(BitArray64 numberOne, BitArray64 numberTwo)
        {
            return !(numberOne == numberTwo);
        }

        // Override of the base class (Object) method for comparing for equality.
        public override bool Equals(object obj)
        {
            // Checks does obj parameter is null
            if (obj == null)
            {
                return false;
            }

            // Checks does obj parameter is of type Student
            var otherNumber = obj as BitArray64;
            if (otherNumber == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return this.bits == otherNumber.bits;
        }

        // This is not override of the base class (Object) Equals(), but instead is supouse to speed up comaparison
        // following Microsoft guidelines in MSDN for the current Student class.
        public bool Equals(BitArray64 otherBitArray)
        {
            // Checks does obj parameter is null
            if (otherBitArray == null)
            {
                return false;
            }

            return this.bits == otherBitArray.bits;
        }

        /// <summary>
        /// Calculates the hashcode for the current instance.
        /// </summary>
        /// <returns>Calculated hashcode.</returns>
        public override int GetHashCode()
        {
            return this.bits.GetHashCode();
        }

        /// <summary>
        /// Enumerates over each bit of the current instance of bits array.
        /// </summary>
        /// <returns>Sequence of bits, starting from oldest bit to yongest one.</returns>
        public IEnumerator<int> GetEnumerator()
        {
            for (int index = 63; index >= 0; index--)
            {
                yield return this[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            foreach (var bit in this)
            {
                output.Append(bit);
            }

            return output.ToString();
        }
    }
}