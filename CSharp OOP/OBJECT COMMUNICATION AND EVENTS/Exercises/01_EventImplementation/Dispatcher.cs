namespace _01_EventImplementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);
    public class Dispatcher
    {
        private string name;
       
        public string Name
        {
            get => this.name;
                set
            {
                this.name = value;
                this.OnNameChange(new NameChangeEventArgs(value));
            }
        }
        public event NameChangeEventHandler NameChange;

        public void OnNameChange(NameChangeEventArgs args)
        {
            NameChange.Invoke(this, args);
        }
     }

}
