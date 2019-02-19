using System;

namespace GenericScale
{
   public class Scale<T>
        where T : IComparable<T>
    {
        private T leftItem;
        private T rightItem;

        public Scale(T leftItem, T rightItem)
        {
            this.leftItem = leftItem;
            this.rightItem = rightItem;
        }

        public T GetHeavier()
        {
            var leftItem = this.leftItem;
            var rightItem = this.rightItem;

            var result = leftItem.CompareTo(rightItem);

            if (result == 1)
            {
                return leftItem;
            }
            else if (result == -1)
            {
                return rightItem;
            }

            return default(T);
        }
    }
}
