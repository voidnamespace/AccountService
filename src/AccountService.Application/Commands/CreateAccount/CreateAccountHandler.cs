using AccountService.Application.DTOs;
using AccountService.Application.Interfaces;
using AccountService.Domain.Entity;
using AccountService.Domain.ValueObjects;
using MediatR;

namespace AccountService.Application.Commands.CreateAccount;

public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, ReadAccountDTO>
{
    private readonly IAccountRepository _accountRepository;


    public CreateAccountHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }


    public async Task<ReadAccountDTO> Handle(CreateAccountCommand command, CancellationToken ct)
    {
        AccountNumberVO accountNumberVO;
        do
        {
            accountNumberVO = AccountNumberVO.Generate();
        }
        while (await _accountRepository
            .ExistsByAccountNumberAsync(accountNumberVO, ct));
        var acc = new Account(command.request.UserId, accountNumberVO);
        await _accountRepository.AddAsync(acc, ct);
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
