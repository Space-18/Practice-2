using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Biblioteca.API.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        [JsonPropertyName("Details")]
        public object Details { get; set; }

        public CodeErrorException(int statusCode, string? message = null, object details = null) : base(statusCode, message)
        {
            Details = details;
        }
    }
}
