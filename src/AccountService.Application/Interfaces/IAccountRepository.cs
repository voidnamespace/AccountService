using AccountService.Domain.Entity;
using AccountService.Domain.ValueObjects;
namespace AccountService.Application.Interfaces;

public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<Account?> GetByAccountNumberAsync(AccountNumberVO accountNumber, CancellationToken ct = default);

    Task<bool> ExistsByAccountNumberAsync(AccountNumberVO accountNumber, CancellationToken ct = default);

    Task AddAsync(Account account, CancellationToken ct = default);

    Task SaveChangesAsync(CancellationToken ct = default);
}
