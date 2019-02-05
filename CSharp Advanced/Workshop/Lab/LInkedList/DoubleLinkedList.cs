using System;

namespace LInkedList
{
    class DoubleLinkedList
    {

        private CoolNode head;

        private CoolNode tail;

        public int Count { get; private set; }

        public object Head
        {
            get
            {
                this.ValidateIfListIsEmpty();

                return this.head.Value;
            }
        }
        public object Tail
        {
            get
            {
                this.ValidateIfListIsEmpty();

                return this.tail.Value;
            }
        }


        public void AddHead(object value)
        {
            var newNode = new CoolNode(value);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                var oldHead = this.head;
                oldHead.Previous = newNode;
                newNode.Next = oldHead;
                this.head = newNode;
            }
            Count++;
        }

        public void AddTail(object value)
        {
            var newNode = new CoolNode(value);

            if (Count == 0)
            {
                this.head = this.tail = newNode;

            }

            else
            {
                var oldeTail = this.tail;
                oldeTail.Next = newNode;
                newNode.Previous = oldeTail;
                this.tail = newNode;
            }
            Count++;
        }

        public object RemoveHead()
        {
            this.ValidateIfListIsEmpty();

            var value = this.head.Value;

            if (Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                var newHead = this.head.Next;
                newHead.Previous = null;
                this.head.Next = null;
                this.head = newHead;
            }
            Count--;
            return value;
        }

        public object RemoveTail()
        {
            this.ValidateIfListIsEmpty();

            var result = this.tail.Value;

            if (Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                var newTail = this.tail.Previous;
                newTail.Next = null;
                this.tail.Previous = null;
                this.tail = newTail;
            }

            Count--;
            return result;
        }

        public void ValidateIfListIsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Sorry, the LinkedList is empty");
            }
        }

        public void ForEach (Action <object> action)
        {
            var curentHead = this.head;

            while (curentHead != null)
            {
                action(curentHead.Value);
                curentHead = curentHead.Next;
            }
        }
        public void Clear()
        {
            this.head = null;
            this.tail = null;
        }
    }
}
