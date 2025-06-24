using Ardalis.SharedKernel;
using Clean.Architecture.ArchitectureTests.CustomRules;
using Clean.Architecture.Core.ContributorAggregate;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;
using Xunit.Abstractions;

namespace Clean.Architecture.ArchitectureTests.Core.ContributorAggregate;
public class AggregateTests
{
  private readonly ITestOutputHelper testOutputHelper;

  public AggregateTests(ITestOutputHelper testOutputHelper)
  {
    this.testOutputHelper = testOutputHelper;
  }

  [Fact]
  public void AggregateRoot_Should_Not_Have_Public_Default_Constructor()
  {
    // Arrange
    // Act 
    TestResult result = Types.InAssembly(typeof(Contributor).Assembly)
                             .That()
                             .ImplementInterface(typeof(IAggregateRoot))
                             .Should()
                             .MeetCustomRule(new DefaultCtorShouldNotBePublicRule())
                             .GetResult();

    // Assert
    result.DisplayFailingTypes(this.testOutputHelper).IsSuccessful.Should().BeTrue();
  }
}
