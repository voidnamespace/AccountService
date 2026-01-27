namespace AccountService.Application.DTOs;

public class CreateAccountRequest
{
    public Guid UserId { get; set; }
}

public class CreateAccountResponse
{
    public Guid AccountId { get; init; }
    public string AccountNumber { get; init; } = default!;
}
