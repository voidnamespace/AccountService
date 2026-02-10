using AccountService.Application.DTOs;
using MediatR;

namespace AccountService.Application.Commands.WithdrawMoney;

public record WithdrawMoneyCommand (WithdrawDTO request) : IRequest;
