namespace ArchDdd.Application.Abstractions.Exceptions;

public sealed class BadRequestException(string message) : Exception(message);
