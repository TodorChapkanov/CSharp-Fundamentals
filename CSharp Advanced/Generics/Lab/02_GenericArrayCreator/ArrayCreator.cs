namespace GenericArrayCreator
{
   public class ArrayCreator
    {
        public static T[] Create<T>(int lenght, T item)
        {
            T[] array = new T[lenght];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = item;
                
            }
            return array;
        }
    }
}
