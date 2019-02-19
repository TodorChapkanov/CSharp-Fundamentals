namespace _04_Froggy
{
    using System.Collections;
    using System.Collections.Generic;


    public class Lake : IEnumerable<int>
    {
        private IList<int> jumps;

        public Lake(int[] stones)
        {
            this.jumps = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.jumps.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.jumps[i];
                }

            }
            for (int i = this.jumps.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.jumps[i];
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
