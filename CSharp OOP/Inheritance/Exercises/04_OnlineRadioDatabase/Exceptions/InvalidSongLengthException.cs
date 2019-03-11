namespace _04_OnlineRadioDatabase.Exceptions
{
    class InvalidSongLengthException : InvalidSongException
    {
        public override string Message => "Invalid song length.";
    }
}
