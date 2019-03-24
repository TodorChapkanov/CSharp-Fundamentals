using P01.Stream_Progress.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamable streamFile;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamable strameFile)
        {
            this.streamFile = strameFile;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamFile.BytesSent * 100) / this.streamFile.Length;
        }
    }
}
