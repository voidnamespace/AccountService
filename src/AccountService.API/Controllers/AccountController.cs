using AccountService.Application.Commands.CreateAccount;
using AccountService.Application.DTOs;
using AccountService.Application.Queries.GetAllAccounts;
using AccountService.Application.Queries.GetByAccountNumberAccount;
using AccountService.Application.Queries.GetByIdAccount;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
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

    [HttpPost]
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


    [HttpGet("{accountId:guid}")]
    public async Task<IActionResult> GetById(Guid accountId, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetByIdAccountQuery(accountId), ct);
        return Ok(result);
    }


    [HttpGet("by-number/{accountNumber}")]
    public async Task<IActionResult> GetByAccountNumber(Guid AccountId,  CancellationToken ct)
    {
        var result = await _mediator.Send(new GetByAccountNumberAccountQuery(AccountId), ct);
        return Ok(result);
    }





}
