namespace AccountsManagerMVVM.Models;

public record User
{
    public User() { }

    public int PersonId { get; init; }
    public string LastName { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string Patronymic { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public bool IsAdmin { get; init; } = false;
    public string FullName => $"{LastName} {FirstName} {Patronymic}".Trim();
}