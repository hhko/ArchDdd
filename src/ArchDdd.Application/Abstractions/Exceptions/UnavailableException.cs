namespace ArchDdd.Application.Abstractions.Exceptions;

public sealed class UnavailableException(string message) : Exception(message);