using System.Runtime.Serialization;

namespace DO
{
    [Serializable]
    internal class DalNotFound : Exception
    {
        public DalNotFound()
        {
        }

        public DalNotFound(string? message) : base(message)
        {
        }

        public DalNotFound(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DalNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}