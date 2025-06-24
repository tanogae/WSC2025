using Ardalis.SharedKernel;
using Clean.Architecture.ArchitectureTests.CustomRules;
using Clean.Architecture.Core.ContributorAggregate;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;
using Xunit.Abstractions;

namespace Clean.Architecture.ArchitectureTests.Core.ContributorAggregate;

public class ValueObjectTests
{
  private readonly ITestOutputHelper testOutputHelper;

  public ValueObjectTests(ITestOutputHelper testOutputHelper)
  {
    this.testOutputHelper = testOutputHelper;
  }

  [Fact]
  public void ValueObject_Should_Be_Sealed()
  {
    // Arrange
    // Act 
    TestResult result = Types.InAssembly(typeof(Contributor).Assembly)
                             .That()
                             .Inherit(typeof(ValueObject))
                             .Should()
                             .BeSealed()
                             .GetResult();

    // Assert
    result.DisplayFailingTypes(this.testOutputHelper).IsSuccessful.Should().BeTrue();
  }

  [Fact]
  public void ValueObject_Should_Not_Have_Public_PropertiesSet()
  {
    // Arrange
    // Act 
    TestResult result = Types.InAssembly(typeof(Contributor).Assembly)
                             .That()
                             .Inherit(typeof(ValueObject))
                             .Should()
                             .MeetCustomRule(new PropertiesSetShouldBeNonPublicRule())
                             .GetResult();

    // Assert
    result.DisplayFailingTypes(this.testOutputHelper).IsSuccessful.Should().BeTrue();
  }

}
