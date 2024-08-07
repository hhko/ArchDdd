﻿using Microsoft.Extensions.Options;
using PrimitiveUtilities;

namespace ArchDdd.Adapters.Persistence.Abstractions.Options.Database;

public class DatabaseOptionsValidator
    : IValidateOptions<DatabaseOptions>
{
    public ValidateOptionsResult Validate(string? name, DatabaseOptions options)
    {
        List<string> validationResult = new();

        if (options.ConnectionString.IsNullOrEmptyOrWhiteSpace())
        {
            validationResult.Add("Connection string is missing. ");
        }

        if (options.MaxRetryCount < 1)
        {
            validationResult.Add("Retry Count is less than one. ");
        }

        if (options.MaxRetryDelay < 1)
        {
            validationResult.Add("Retry delay is less than one. ");
        }

        if (options.CommandTimeout < 1)
        {
            validationResult.Add("Command timeout is less than one. ");
        }

        if (validationResult.Count is not 0)
        {
            return ValidateOptionsResult.Fail(validationResult);
        }

        return ValidateOptionsResult.Success;
    }
}