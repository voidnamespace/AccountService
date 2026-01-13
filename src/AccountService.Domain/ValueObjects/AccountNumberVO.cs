namespace AccountService.Domain.ValueObjects;

public class AccountNumberVO
{

    public string _accountNumber { get; private set; }
    private AccountNumberVO() { }

    public string Value => _accountNumber;

    public AccountNumberVO(string accountNumber)
    {
        if (string.IsNullOrWhiteSpace(accountNumber))
            throw new ArgumentNullException("account number is required");
        if (accountNumber.Length != 12)
            throw new ArgumentException("symbol's limit reached");
        if (accountNumber.All(char.IsDigit))
            throw new ArgumentException("Account number must contain only digits");
    }

}
