namespace _05_GenericCountMethodStrings
{
    using System.Collections.Generic;
    
    class Data<T>
        //where T : IComparer<string>
    {
        private IList<T> allData;



        public Data(IList<T> allData)
        {
            this.allData = allData;

        }
        
        public int  CountString(string compareWith)
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
