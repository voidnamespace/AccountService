using AccountService.Domain.Enums;

namespace AccountService.Application.DTOs;

public class DepositRequest
{
    public string AccountNumber { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public Currency Currency { get; init; } 
}
