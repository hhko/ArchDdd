using ArchDdd.Application.Abstractions;
using ArchDdd.Application.Abstractions.CQRS;
using ArchDdd.Application.UseCases.Users.Queries;
using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;

namespace ArchDdd.Application.UseCases.Users.Commands.DeletePermission;

internal sealed class DeletePermissionCommandUseCase(
    IAuthorizationRepositoryQuery authorizationRepositoryQuery,
    IAuthorizationRepositoryCommand authorizationRepositoryCommand,
    IValidator validator)
    : ICommandUseCase<DeletePermissionCommand>
{
    private readonly IAuthorizationRepositoryQuery _authorizationRepositoryQuery = authorizationRepositoryQuery;
    private readonly IAuthorizationRepositoryCommand _authorizationRepositoryCommand = authorizationRepositoryCommand;
    private readonly IValidator _validator = validator;

    public async Task<IResult> Handle(DeletePermissionCommand command, CancellationToken cancellationToken)
    {
        // 도메인 타입 생성
        var parsePermissionNameResult = Enum.TryParse<PermissionName>(command.PermissionName, out var permissionName);

        _validator
            .If(parsePermissionNameResult is false, Error.InvalidArgument($"{command.PermissionName} is not a valid PermissionName"));

        if (_validator.IsInvalid)
        {
            return _validator.Failure();
        }

        // 도메인 존재 유/무
        var permission = await _authorizationRepositoryQuery.GetPermissionAsync<Permission>(
            permissionName, 
            cancellationToken);

        _validator
            .If(permission is null, Error.NotFound(
                // $"{subjectToFind}.{nameof(NotFound)}"  ->  Permission.NotFound
                subjectToFind: nameof(Permission),
                uniqueValue: command.PermissionName,
                additionalMessage: $"{command.PermissionName} not found in the database"));

        if (_validator.IsInvalid)
        {
            return _validator.Failure();
        }

        // 도메인 삭제
        await _authorizationRepositoryCommand
            .DeletePermissionAsync(permission!);

        return Result.Success();
    }
}
