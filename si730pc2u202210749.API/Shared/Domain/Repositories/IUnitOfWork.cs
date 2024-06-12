namespace si730pc2u202210749.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}