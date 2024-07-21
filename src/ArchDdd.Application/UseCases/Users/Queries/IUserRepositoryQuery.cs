namespace ArchDdd.Application.UseCases.Users.Queries;

public interface IUserRepositoryQuery //: IRepositoryQuery
{
    //Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken);

    //Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken);

    Task<T?> GetByUsernameAsync<T>(string username, CancellationToken cancellationToken) where T : class;
    //Task<GetUserByUsernameResponse> GetByUsernameAsync2(Username username, CancellationToken cancellationToken);

    //Task<Role?> GetRolePermissionsAsync(Role role, CancellationToken cancellationToken);

    //Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken);

    Task<bool> IsEmailTakenAsync(string email, CancellationToken cancellationToken);
}