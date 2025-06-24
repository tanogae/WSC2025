namespace Clean.Architecture.Core.ContributorAggregate;

public sealed class PhoneNumber_PublicSet(string countryCode,
  string number,
  string? extension) : ValueObject
{
  public string CountryCode { get; set; } = countryCode;
  public string Number { get; private set; } = number;
  public string? Extension { get; private set; } = extension;

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return CountryCode;
    yield return Number;
    yield return Extension ?? String.Empty;
  }
}
