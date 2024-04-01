
using System.Runtime.Serialization;

namespace DisasterResponseSystem.Core.Exception
{
    public class DataNotFoundException : BaseFriendlyException
    {

        public DataNotFoundException(object extra = null) : base(extra)
        {
        }

        public DataNotFoundException(string message, object extra = null)
            : base(message, extra)
        {
        }

        public DataNotFoundException(string title, string message, object extra = null) : base(title, message, extra)
        {
        }

        public DataNotFoundException(string title, string message, string url, object extra = null) : base(title, message, url, extra)
        {
        }

        public DataNotFoundException(string title, string message, string url, string urlTitle, object extra = null) : base(title, message, url, urlTitle, extra)
        {
        }

        protected DataNotFoundException(SerializationInfo info, StreamingContext context, object extra = null)
            : base(info, context, extra)
        {
        }
    }
}
