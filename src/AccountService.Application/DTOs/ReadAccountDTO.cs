namespace AccountService.Application.DTOs;

public class ReadAccountDTO
{
    public Guid Id { get; init; }

    public Guid UserId { get; init; }
    public string AccountNumber { get; init; } = default!;
    public decimal Balance { get; init; }
    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; init; }

    public bool IsActive { get; init; }
}
