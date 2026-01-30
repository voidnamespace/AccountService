

using AccountService.Application.DTOs;
using AccountService.Application.Interfaces;
using MediatR;

namespace AccountService.Application.Queries.GetByAccountNumberAccount;

public class GetByAccountNumberAccountHandler : IRequestHandler<GetByAccountNumberAccountQuery, ReadAccountDTO>
{
    private readonly IAccountRepository _accountRepository;


    public GetByAccountNumberAccountHandler (IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository; 
    }




    public async Task<ReadAccountDTO> Handle (GetByAccountNumberAccountQuery query, CancellationToken ct)
    {
        var acc = await _accountRepository.GetByIdAsync(query.AccountId, ct);

        if (acc == null)
            throw new KeyNotFoundException("no account found");

        return new ReadAccountDTO
        {
            Id = acc.Id,
            UserId = acc.UserId,
            AccountNumber = acc.AccountNumber.Value,
            Balance = acc.Balance,
            CreatedAt = acc.CreatedAt,
            UpdatedAt = acc.UpdatedAt,
            IsActive = acc.IsActive
        };
    }


}
