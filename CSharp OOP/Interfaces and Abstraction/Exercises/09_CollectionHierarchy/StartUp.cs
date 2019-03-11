namespace _09_CollectionHierarchy
{
    using _09_CollectionHierarchy.Models;
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var removeCommandsCount = int.Parse(Console.ReadLine());
            var builder = new StringBuilder();
            var addcollection = new AddCollection();
            var removeCollection = new AddRemoveCollection();
            var myList = new MyList();

            for (int i = 0; i < 3; i++)
            {
                for (int c = 0; c < input.Length; c++)
                {
                    if (i == 0)
                    {
                        var index =IndexToString( addcollection.Add(input[c]));
                       builder.Append(index.ToString() + ' ');
                    }

                    else if (i ==1)
                    {
                        var index = IndexToString(removeCollection.Add(input[c]));
                        builder.Append(index + ' ');
                    }

                    else
                    {
                        var index = IndexToString(myList.Add(input[c]));
                        builder.Append(index + ' ');
                    }
                }
                
                builder.AppendLine();
            }

            for (int i = 0; i < 2; i++)
            {
                for (int c = 0; c < removeCommandsCount; c++)
                {
                    if (i == 0)
                    {
                        builder.Append(removeCollection.Remove()+ ' ');
                    }

                    else
                    {
                        builder.Append(myList.Remove() + ' ');
                    }
                    
                }

                builder.AppendLine();
            }

            Console.Write(builder);
            
        }

        private static string IndexToString(int index)
        {
            var result = index.ToString();
            return result;
        }
    }
}
