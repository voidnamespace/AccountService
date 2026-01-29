using AccountService.Application.DTOs;
using AccountService.Application.Interfaces;
using MediatR;

namespace AccountService.Application.Queries.GetAllAccounts;

public class GetAllAccountsHandler 
    : IRequestHandler<GetAllAccountsQuery, IEnumerable<ReadAccountDTO>>
{
    private readonly IAccountRepository _accountRepository;

    public GetAllAccountsHandler (IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository; 
    }



    public async Task<IEnumerable<ReadAccountDTO>> Handle(
    GetAllAccountsQuery query,
    CancellationToken ct)
    {
        var accounts = await _accountRepository.GetAllAsync(ct);

        return accounts.Select(account => new ReadAccountDTO
        {
            Id = account.Id,
            UserId = account.UserId,
            AccountNumber = account.AccountNumber.Value,
            Balance = account.Balance,
            CreatedAt = account.CreatedAt,
            UpdatedAt = account.UpdatedAt,
            IsActive = account.IsActive
        });
    }



}
