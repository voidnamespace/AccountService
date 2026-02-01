using AccountService.Application.DTOs;
using MediatR;

namespace AccountService.Application.Queries.GetByAccountNumberAccount;

public record GetByAccountNumberAccountQuery(Guid AccountId) : IRequest<ReadAccountDTO>;

