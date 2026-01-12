namespace AccountService.Domain.Entity;

public class Account
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public string AccountNumber { get; set; } = default!;
    public decimal Balance { get; set; }
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    private Account() { }
    public Account (Guid userId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        AccountNumber = GenerateAccountNumber();
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
        if (amount < 0)
            throw new ArgumentException("Amount must be greater than zero");
        if (amount > Balance)
            throw new ArgumentException($"insufficient balance");
        Balance -= amount;
        UpdatedAt = DateTime.UtcNow;
    }
    public void AddBalance (decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount must be greater than zero");
        Balance += amount;
        UpdatedAt = DateTime.UtcNow;
    }

    public static string GenerateAccountNumber()
    {
        return Random.Shared.NextInt64(100000000000, 999999999999).ToString();
    }

}
