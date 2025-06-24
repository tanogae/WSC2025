using Clean.Architecture.ArchitectureTests.CustomRules;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;
using Xunit.Abstractions;

namespace Clean.Architecture.ArchitectureTests.Web;
public class WebTests
{
  private readonly ITestOutputHelper testOutputHelper;

  public WebTests(ITestOutputHelper testOutputHelper)
  {
    this.testOutputHelper = testOutputHelper;
  }

  [Fact]
  public void Request_Should_Have_Response()
  {
    // Arrange
    // Act 
    TestResult result = Types.InAssembly(typeof(Program).Assembly)
                             .That()
                             .AreClasses()
                             .And()
                             .AreNotAbstract()
                             .And()
                             .HaveNameEndingWith("Request")
                             .Should()
                             .HaveMatchingTypeWithName(x => x.Name.Replace("Request", "Response"))
                             .GetResult();

    // Assert
    result.DisplayFailingTypes(this.testOutputHelper).IsSuccessful.Should().BeTrue();
  }

  [Fact]
  public void Request_Should_Have_Validator()
  {
    // Arrange
    // Act 
    TestResult result = Types.InAssembly(typeof(Program).Assembly)
                             .That()
                             .AreClasses()
                             .And()
                             .AreNotAbstract()
                             .And()
                             .HaveNameEndingWith("Request")
                             .Should()
                             .MeetCustomRule(new ValidatorCustomRule())
                             .GetResult();

    // Assert
    result.DisplayFailingTypes(this.testOutputHelper).IsSuccessful.Should().BeTrue();
  }

}
