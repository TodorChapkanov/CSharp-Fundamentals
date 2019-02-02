namespace _04_CopyBinaryFile
{
    using System;
    using System.Linq;
    using System.IO;

    public class CopyBinaryFile
    {
        public const string inputPath = @"../../../sliceMe.mp4";
        
        public const string outputParh = @"../../../output.mp4";

        public static void Main()
        {
            
            using (var reader = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (var writer = new FileStream(outputParh, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    while (true)
                    {
                        var buffer = new byte[4096];

                        var byteRead = reader.Read(buffer, 0, buffer.Length);
                        if (byteRead == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, byteRead);
                    }
                }
                
            }
        }
    }
}
