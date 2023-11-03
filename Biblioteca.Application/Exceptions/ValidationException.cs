using FluentValidation.Results;

namespace Biblioteca.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base("Se presentaron uno o más errores de validación.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(x => x.PropertyName, y => y.ErrorMessage)
                .ToDictionary(failuresGroup => failuresGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
