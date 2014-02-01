// Define a class BitArray64 to hold 64 bit values inside an ulong value.
// Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

namespace MyBitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<int>
    {
        private ulong bits;

        public BitArray64(ulong initialValue = 0)
        {
            this.Bits = initialValue;
        }
        
        public ulong Bits
        {
            get
            {
                return this.bits;
            }

            set
            {
                this.bits = value;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index <= 63)
                {
                    return (this.Bits & (1ul << index)) == 1 ? 1 : 0;
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid index specified!");
                }
            }

            set
            {
                if ((index >= 0 && index <= 63) && (value == 1 || value == 0))
                {
                    ulong mask = 1 << index;
                    switch (value)
                    {
                        case 1:
                            this.Bits = this.Bits | mask;
                            break;
                        case 2:
                            this.Bits = this.Bits & ~mask;
                            break;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid index or value specified!");
                }
            }
        }

        public static bool operator ==(BitArray64 numberOne, BitArray64 numberTwo)
        {
            return BitArray64.Equals(numberOne, numberTwo);
        }

        public static bool operator !=(BitArray64 numberOne, BitArray64 numberTwo)
        {
            return !BitArray64.Equals(numberOne, numberTwo);
        }

        public override bool Equals(object obj)
        {
            BitArray64 otherNumber = obj as BitArray64;
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

        public override int GetHashCode()
        {
            return this.Bits.GetHashCode();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int index = 0; index < 63; index++)
            {
                yield return this[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
