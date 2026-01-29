using AccountService.Application.Interfaces;
using AccountService.Domain.Entity;
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
        var account = new Account(command.request.UserId);
        await _accountRepository.AddAsync(account, ct);

    }
}
