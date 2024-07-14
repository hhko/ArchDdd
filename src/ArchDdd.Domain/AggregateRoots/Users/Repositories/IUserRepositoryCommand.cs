﻿using ArchDdd.Domain.Abstractions.Repositories;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;

namespace ArchDdd.Domain.AggregateRoots.Users.Repositories;

public interface IUserRepositoryCommand : IRepositoryCommand
{
    void Add(User user);

    void Update(User user);
}