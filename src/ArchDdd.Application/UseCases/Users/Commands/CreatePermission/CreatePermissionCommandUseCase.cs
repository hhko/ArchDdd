using ArchDdd.Application.Abstractions.CQRS;
using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;

namespace ArchDdd.Application.UseCases.Users.Commands.CreatePermission;

internal sealed class CreatePermissionCommandUseCase()
    //IAuthorizationRepository authorizationRepository, 
    //IValidator validator)
    : ICommandUseCase<CreatePermissionCommand>
{
    //private readonly IAuthorizationRepository _authorizationRepository = authorizationRepository;
    //private readonly IValidator _validator = validator;

    public async Task<IResult> Handle(CreatePermissionCommand command, CancellationToken cancellationToken)
    {
        //var permissionToCreateResult = Permission.CreatePermission(
        //    command.PermissionName, 
        //    command.RelatedAggregateRoot, 
        //    command.RelatedEntity, 
        //    command.PermissionType, 
        //    command.AllowedProperties);

        //_validator
        //    .Validate(permissionToCreateResult);

        //if (_validator.IsInvalid)
        //{
        //    return _validator.Failure();
        //}

        //var permissionFromDatabase = await _authorizationRepository.GetPermissionAsync(Enum.Parse<PermissionName>(permissionToCreateResult.Value.Name), cancellationToken);


        //_validator
        //    .If(permissionFromDatabase is not null, Error.AlreadyExists<Permission>(permissionToCreateResult.Value.Name));

        //if (_validator.IsInvalid)
        //{
        //    return _validator.Failure();
        //}

        //await _authorizationRepository
        //    .CreatePermissionAsync(permissionToCreateResult.Value);

        await Task.CompletedTask;

        return Result.Success();
    }
}