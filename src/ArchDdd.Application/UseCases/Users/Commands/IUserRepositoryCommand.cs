using ArchDdd.Domain.AggregateRoots.Users;

namespace ArchDdd.Application.UseCases.Users.Commands;

public interface IUserRepositoryCommand //: IRepositoryCommand
{
    void Add(User user);

    void Update(User user);
}