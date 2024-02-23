using PermitRequestApp.Domain.Abstractions;

namespace PermitRequestApp.Domain.ADUsers;
public sealed class ADUser : Entity
{
    public ADUser(string firstName, string lastName, string email, UserType userType, Guid? managerId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserType = userType;
        ManagerId = managerId;
    }

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public UserType UserType { get; private set; } = UserType.WhiteCollarEmployee;

    public Guid? ManagerId { get; private set; }
    public ADUser? Manager { get; private set; }

    public static ADUser Create(string firstName, string lastName, string email, UserType userType, Guid? managerId)
    {
        ADUser user = new(firstName, lastName, email, userType, managerId);

        return user;
    }

    public static ADUser CreateSeedData(Guid id, string firstName, string lastName, string email, UserType userType, Guid? managerId)
    {
        ADUser user = new(firstName, lastName, email, userType, managerId);
        user.Id = id;

        return user;
    }

    public void Update(string firstName, string lastName, string email, UserType userType, Guid? managerId)
    {
        if (string.IsNullOrEmpty(firstName) || firstName.Length < 3)
        {
            throw new ArgumentException("First name is required and must be at least 3 characters long");
        }

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserType = userType;
        ManagerId = managerId;
    }
}
