using System.Collections.Generic;

namespace _06_GenericCountMethodDoubles
{
    class Data<T>
    {
        private IList<T> allData;
        
        public Data(IList<T> allData)
        {
            this.allData = allData;

        }

        public int CountString(double compareWith)
        {
            var count = 0;
            for (int i = 0; i < allData.Count; i++)
            {
                var result = compareWith.CompareTo(allData[i]);

                if (result == -1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
