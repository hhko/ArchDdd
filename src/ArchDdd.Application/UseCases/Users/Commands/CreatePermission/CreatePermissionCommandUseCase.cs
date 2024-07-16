﻿using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using ArchDdd.Application.Abstractions;
using ArchDdd.Application.Abstractions.CQRS;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;
using ArchDdd.Domain.AggregateRoots.Users.Repositories;

namespace ArchDdd.Application.UseCases.Users.Commands.CreatePermission;

internal sealed class CreatePermissionCommandUseCase(
    IAuthorizationRepositoryQuery authorizationRepositoryQuery,
    IAuthorizationRepositoryCommand authorizationRepositoryCommand,
    IValidator validator)
    : ICommandUseCase<CreatePermissionCommand>
{
    private readonly IAuthorizationRepositoryQuery _authorizationRepositoryQuery = authorizationRepositoryQuery;
    private readonly IAuthorizationRepositoryCommand _authorizationRepositoryCommand = authorizationRepositoryCommand;
    private readonly IValidator _validator = validator;

    public async Task<IResult> Handle(CreatePermissionCommand command, CancellationToken cancellationToken)
    {
        var permissionToCreateResult = Permission.Create(
            command.PermissionName,
            command.RelatedAggregateRoot,
            command.RelatedEntity,
            command.PermissionType,
            command.AllowedProperties);

        _validator
            .Validate(permissionToCreateResult);

        if (_validator.IsInvalid)
        {
            return _validator.Failure();
        }

        var permissionFromDatabase = await _authorizationRepositoryQuery.GetPermissionAsync<Permission>(Enum.Parse<PermissionName>(permissionToCreateResult.Value.Name), cancellationToken);

        //_validator
        //    .If(permissionFromDatabase is not null, Error.AlreadyExists<Permission>(permissionToCreateResult.Value.Name));

        if (_validator.IsInvalid)
        {
            return _validator.Failure();
        }

        await _authorizationRepositoryCommand
            .CreatePermissionAsync(permissionToCreateResult.Value);

        return Result.Success();
    }
}