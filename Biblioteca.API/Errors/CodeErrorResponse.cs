namespace Biblioteca.API.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

        public CodeErrorResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El request contiene errores.",
                401 => "No autorizado.",
                404 => "No existe.",
                500 => "Error interno del servidor.",
                _ => string.Empty
            }; ;
        }
    }
}
