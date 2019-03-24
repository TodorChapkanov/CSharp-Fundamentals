namespace P01.Stream_Progress
{
    using P01.Stream_Progress.Interfaces;

    public class StreamFile : IStreamable
    {
        private string name;

        public StreamFile(string name, int length, int bytesSent)
        {
            this.name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
