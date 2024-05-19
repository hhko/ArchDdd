namespace ArchDdd.Application.Abstractions.Exceptions;

public sealed class NotFoundException(string message) : Exception(message);
