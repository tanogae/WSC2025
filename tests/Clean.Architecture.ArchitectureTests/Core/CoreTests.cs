using Ardalis.SharedKernel;
using Clean.Architecture.Core.ContributorAggregate;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;
using Xunit.Abstractions;

namespace Clean.Architecture.ArchitectureTests.Core;
public class CoreTests
{
  private readonly ITestOutputHelper testOutputHelper;

  public CoreTests(ITestOutputHelper testOutputHelper)
  {
    this.testOutputHelper = testOutputHelper;
  }

  [Fact]
  public void Core_Should_Not_Reference_Other_Projects()
  {
    // Arrange
    // Act 
    TestResult result = Types.InAssembly(typeof(Contributor).Assembly)
                             .That()
                             .Inherit(typeof(DomainEventBase))
                             .ShouldNot()
                             .HaveDependencyOnAll("AspireHost", "Infrastructure", "ServiceDefaults", "UseCases", "Web")
                             .GetResult();

    // Assert
    result.DisplayFailingTypes(this.testOutputHelper).IsSuccessful.Should().BeTrue();
  }
}
