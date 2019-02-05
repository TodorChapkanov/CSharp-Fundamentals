namespace LInkedList
{
   public class CoolNode
    {
        public CoolNode(object value)
        {
            this.Value = value;
        }
        
        public object Value { get; set; }

        public CoolNode Next { get;  set; }

        public CoolNode Previous { get; set; }
    }
}
