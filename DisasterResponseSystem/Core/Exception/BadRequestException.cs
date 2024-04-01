using System.Runtime.Serialization;

namespace DisasterResponseSystem.Core.Exception
{
    public class BadRequestException : BaseFriendlyException
    {
        public BadRequestException(object extra = null)
            : base(extra)
        {
        }

        public BadRequestException(string message, object extra = null)
            : base(message, extra)
        {
        }

        public BadRequestException(string title, string message, object extra = null) : base(title, message, extra)
        {
        }

        public BadRequestException(string title, string message, string url, object extra = null) : base(title, message, url, extra)
        {
        }

        public BadRequestException(string title, string message, string url, string urlTitle, object extra = null) : base(title, message, url, urlTitle, extra)
        {
        }


        protected BadRequestException(SerializationInfo info, StreamingContext context, object extra = null)
            : base(info, context, extra)
        {
        }
    }
}
