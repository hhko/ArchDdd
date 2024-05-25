using ArchDdd.Application.Abstractions.CQRS;
using ArchDdd.Application.UseCases.Users.Commands.RegisterUser;
using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;
using ArchDdd.Domain.AggregateRoots.Users;
using System.ComponentModel.DataAnnotations;
using System.Security;
using ArchDdd.Application.Abstractions;
using static ArchDdd.Domain.AggregateRoots.Users.Errors.DomainErrors;

namespace ArchDdd.Application.UseCases.Users.Commands.AddPermissionToRole;

internal sealed class AddPermissionToRoleCommandHandler(
    IUserRepository userRepository,
    IValidator validator)
    : ICommandUseCase<AddPermissionToRoleCommand>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IValidator _validator = validator;

    public async Task<IResult> Handle(AddPermissionToRoleCommand command, CancellationToken cancellationToken)
    {
        var role = Role.FromName(command.Role);
        var permission = Permission.FromName(command.Permission);

        _validator
            .If(role is null, RoleError.NotFound(command.Role))
            .If(role == Role.Administrator, RoleError.InvalidOperation(role!.Name))
            .If(permission is null, PermissionError.NotFound(command.Permission));

        if (_validator.IsInvalid)
        {
            return _validator.Failure();
        }

        //var roleWithPermissions = await _userRepository
        //    .GetRolePermissionsAsync(role!, cancellationToken);

        //_validator
        //    .If(roleWithPermissions!.Permissions.Any(x => x.Name == permission!.Name), Error.AlreadyExists(nameof(Permission), command.Permission));

        //if (_validator.IsInvalid)
        //{
        //    return _validator.Failure();
        //}

        //roleWithPermissions!
        //    .Permissions
        //    .Add(permission!);

        return Result.Success();
    }
}
