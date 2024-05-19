namespace ArchDdd.Application.Abstractions.Exceptions;

public sealed class ForbidException(string message) : Exception(message);
