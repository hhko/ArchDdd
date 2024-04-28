namespace ArchDdd.Domain.Abstractions.Results.Contracts;

public interface IValidationResult
{
    Error[] ValidationErrors { get; }
}
