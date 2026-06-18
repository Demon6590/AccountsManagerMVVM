namespace AccountsManagerMVVM.Models;

public record User(int PersonId, string LastName, string FirstName, string Patronymic, string Email, string Password,bool IsAdmin = false)
{
    
    public string FullName => $"{LastName} {FirstName} {Patronymic}";
};