
using AccountService.Application.DTOs;
using AccountService.Application.Interfaces;
using MediatR;

namespace AccountService.Application.Commands.CreateAccount;

public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
{
    private readonly IAccountRepository _accountRepository;


    public CreateAccountHandler (IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository; 
    }



    public async Task Handle (CreateAccountCommand command, CancellationToken ct)
    {
        
    }





}
