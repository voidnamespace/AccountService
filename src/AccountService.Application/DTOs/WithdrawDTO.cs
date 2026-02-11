

namespace AccountService.Application.DTOs;

public class WithdrawRequest
{
    public string AccountNumber { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public string Currency { get; init; } = string.Empty;
}
