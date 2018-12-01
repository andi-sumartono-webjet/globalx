namespace Sorting.Infrastructure.Exceptions
{
    [System.Serializable]
    public class PathNeedToBeSetException : System.Exception
    {
        public PathNeedToBeSetException() { }
        public PathNeedToBeSetException(string message) : base(message) { }
        public PathNeedToBeSetException(string message, System.Exception inner) : base(message, inner) { }
    }
}