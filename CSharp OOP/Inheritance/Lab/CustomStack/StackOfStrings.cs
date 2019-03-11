using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    class StackOfStrings
    {
        private List<string> customStack;

        public StackOfStrings()
        {
            customStack = new List<string>();
        }

        public void Push(string data)
        {
            customStack.Add(data);
        }
        public string Pop()
        {
            this.ValidateCustomStacIsEmpti();
            var data = GetLastElement();
            this.customStack.Remove(data);
            return data;
        }

        public string Peek()
        {
            this.ValidateCustomStacIsEmpti();
            var data = GetLastElement();
            return data;
        }

        public bool IsEmpty()
        {
            return customStack.Count < 1;
        }

        private void ValidateCustomStacIsEmpti()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
        }

        private string GetLastElement()
        {
            var data = customStack.Last();
            return data;
        }
    }
}
