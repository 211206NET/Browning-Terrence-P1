using System.Runtime.Serialization;

namespace WebAPI.Controllers
{
    [Serializable]
    internal class DuplicateRecordException : Exception
    {
        public DuplicateRecordException()
        {
        }

        public DuplicateRecordException(string? message) : base(message)
        {
        }

        public DuplicateRecordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DuplicateRecordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}