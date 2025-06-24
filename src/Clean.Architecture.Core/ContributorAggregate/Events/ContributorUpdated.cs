namespace Clean.Architecture.Core.ContributorAggregate.Events;

/// <summary>
/// A domain event that is dispatched whenever a contributor is updated.
/// The UpdateContributorService is used to dispatch this event.
/// </summary>
internal sealed class ContributorUpdated(int contributorId) : DomainEventBase
{
  public int ContributorId { get; init; } = contributorId;
}
