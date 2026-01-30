using AccountService.Application.Interfaces;
using AccountService.Domain.Entity;
using AccountService.Domain.ValueObjects;
using MediatR;

namespace AccountService.Application.Commands.CreateAccount;

public class CreateAccountHandler : IRequestHandler<CreateAccountCommand>
{
    private readonly IAccountRepository _accountRepository;


    public CreateAccountHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }


    public async Task Handle(CreateAccountCommand command, CancellationToken ct)
    {
        AccountNumberVO accountNumberVO;
        do
        {
            accountNumberVO = AccountNumberVO.Generate();
        }
        while (await _accountRepository
            .ExistsByAccountNumberAsync(accountNumberVO, ct));
        var account = new Account(command.request.UserId, accountNumberVO);
        await _accountRepository.AddAsync(account, ct);

    }
}
