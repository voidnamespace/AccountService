using AccountService.Domain.ValueObjects;
namespace AccountService.Domain.Entity;

public class Account
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }
    public AccountNumberVO AccountNumber { get; private set; } = default!;
    public decimal Balance { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public bool IsActive { get; private set; }

    private Account() { }
    public Account (Guid userId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        AccountNumber = AccountNumberVO.Generate();
        Balance = 0;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        IsActive = true;
    }

    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Withdraw (decimal amount)
    {
        if (!IsActive)
            throw new InvalidOperationException("Account is inactive");
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero");
        if (amount > Balance)
            throw new InvalidOperationException($"insufficient balance");
        Balance -= amount;
        UpdatedAt = DateTime.UtcNow;
    }
    public void Deposit (decimal amount)
    {
        if (!IsActive)
            throw new InvalidOperationException("Account is inactive");
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero");
        Balance += amount;
        UpdatedAt = DateTime.UtcNow;
    }
}
