using System;

namespace CustomList
{
    class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Counter { get; private set; }

        public int this[int index]
        {
            get
            {
                ValidateIndexIsOutOfRange(index);
                return items[index];
            }

            set
            {
                ValidateIndexIsOutOfRange(index);
                items[index] = value;
            }
        }

        private void Resize()
        {
            var curentLength = items.Length;
            int[] copy = new int[curentLength * 2];

            for (int i = 0; i < curentLength; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        

        

        public void Add(int item)
        {
            if (this.Counter == this.items.Length)
            {
                Resize();
            }

            this.items[this.Counter] = item;
            this.Counter++;
        }

        public void Insert( int index, int value)
        {
            ValidateIndexIsOutOfRange(index);
            if (this.Counter == this.items.Length)
            {
                Resize();
            }
            ShiftRigth(index);
            this.items[index] = value;
        }

        public int RemoveAt(int index)
        {
            ValidateIndexIsOutOfRange(index);

            var itemOnIndex = this.items[index];
            this.items[index] = default(int);
            ShiftLeft(index);
            

            this.Counter--;
            var isLessThanHalf = ValidateLengthOfList();
            if (isLessThanHalf)
            {
                Shrinc();
            }

            return itemOnIndex;
        }

        public int Count()
        {
            return this.Counter;
        }

        public bool Contains(int value)
        {
            

            for (int i = 0; i < this.Counter; i++)
            {
                if (this.items[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndexIsOutOfRange(firstIndex);
            ValidateIndexIsOutOfRange(secondIndex);
            var itemOnFirsIndex = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = itemOnFirsIndex;
        }

        private void ShiftLeft(int inde)
        {

            for (int i = inde; i < this.items.Length - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void ShiftRigth(int index)
        {
            for (int i = this.Counter; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        
        private void Shrinc()
        {
            var copy = new int[this.items.Length / 2];
            for (int i = 0; i < items.Length / 2; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void ValidateIndexIsOutOfRange(int index)
        {
            if (index >= this.Counter)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        private bool ValidateLengthOfList()
        {
            var isLessThanHalf = false;
            if (this.Counter <= this.items.Length / 2)
            {
                isLessThanHalf = true;
            }
            return isLessThanHalf;
        }
    }
}
