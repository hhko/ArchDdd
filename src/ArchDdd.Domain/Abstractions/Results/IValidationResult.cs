namespace ArchDdd.Domain.Abstractions.Results;

public interface IValidationResult
{
    Error[] ValidationErrors { get; }
}
