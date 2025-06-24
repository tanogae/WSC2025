namespace Clean.Architecture.Core.ContributorAggregate;

public class Contributor_PublicDefaultContructor : EntityBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public string Name { get; private set; } = null!;
  public ContributorStatus Status { get; private set; } = ContributorStatus.NotSet;
  public PhoneNumber? PhoneNumber { get; private set; }

  public Contributor_PublicDefaultContructor()
  {
  }

  public void SetPhoneNumber(string phoneNumber) => PhoneNumber = new PhoneNumber(string.Empty, phoneNumber, string.Empty);

  public void UpdateName(string newName) => Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
}
