using Ardalis.SharedKernel;
using Clean.Architecture.Core.ContributorAggregate;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;
using Xunit.Abstractions;

namespace Clean.Architecture.ArchitectureTests.Core.ContributorAggregate;
public class EventTests
{
  private readonly ITestOutputHelper testOutputHelper;

  public EventTests(ITestOutputHelper testOutputHelper)
  {
    this.testOutputHelper = testOutputHelper;
  }

  [Fact]
  public void Event_Should_Have_Suffix_Event()
  {
    // Arrange
    // Act 
    TestResult result = Types.InAssembly(typeof(Contributor).Assembly)
                             .That()
                             .Inherit(typeof(DomainEventBase))
                             .Should()
                             .HaveNameEndingWith("Event")
                             .GetResult();

    // Assert
    result.IsSuccessful.Should().BeTrue();
  }

  [Fact]
  public void Event_Should_Have_Suffix_Event_DisplayFailingTypes()
  {
    // Arrange
    // Act 
    TestResult result = Types.InAssembly(typeof(Contributor).Assembly)
                             .That()
                             .Inherit(typeof(DomainEventBase))
                             .Should()
                             .HaveNameEndingWith("Event")
                             .GetResult();

    // Assert
    result.DisplayFailingTypes(this.testOutputHelper).IsSuccessful.Should().BeTrue();
  }
}
