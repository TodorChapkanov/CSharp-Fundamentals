using System.Collections.Generic;
namespace _04_GenericSwapMethodIntegers
{
    using System.Text;
    
    public class Box<T>
    {
        private IList<T> allData;



        public Box(IList<T> allData)
        {
            this.allData = allData;

        }

        public void Swap(int firstIndex, int seconIndex)
        {
            var curenData = allData[firstIndex];
            allData[firstIndex] = allData[seconIndex];
            allData[seconIndex] = curenData;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < allData.Count; i++)
            {
                result.AppendLine($"{typeof(T)}: {this.allData[i]}");
            }
            return result.ToString();
        }
    }
}
