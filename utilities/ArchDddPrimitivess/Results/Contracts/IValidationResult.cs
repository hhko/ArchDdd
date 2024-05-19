namespace ArchDddPrimitivess.Results.Contracts;

public interface IValidationResult
{
    Error[] ValidationErrors { get; }
}
