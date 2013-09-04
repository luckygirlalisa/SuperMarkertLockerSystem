using System;

namespace SuperMarketLockerSystem
{
    [Serializable()]
    internal class StoreBagInFullLockerException : Exception
    {
        public StoreBagInFullLockerException(string message) : base(message){ }
    }
}