using System;
using System.Runtime.Serialization;

namespace MHP.CodingChallenge.Backend.Mapping.Data
{
    public class ArticleMappingException : Exception
    {
        public ArticleMappingException()
        {
        }

        public ArticleMappingException(string message) : base(message)
        {
        }

        public ArticleMappingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArticleMappingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
