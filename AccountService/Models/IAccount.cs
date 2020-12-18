namespace AccountService.Models
{
    public interface IAccount
    {
        string AccountName { get; set; }
        string AccountType { get; set; }
        string IDType { get; set; }
    }
}