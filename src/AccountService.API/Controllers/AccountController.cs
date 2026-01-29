using AccountService.Application.Commands.CreateAccount;
using AccountService.Application.DTOs;
using AccountService.Application.Queries.GetAllAccounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace AccountService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{

    private readonly IMediator _mediator;

    public AccountController (IMediator mediator)
    {
        _mediator = mediator; 
    }

    [HttpPost("accounts")]
    public async Task<IActionResult> CreateAccount(
    CreateAccountRequest request,
    CancellationToken ct)
    {
        await _mediator.Send(new CreateAccountCommand(request), ct);
        return Accepted();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await _mediator.Send(new GetAllAccountsQuery(), ct);
        return Ok(result);
    }



}
