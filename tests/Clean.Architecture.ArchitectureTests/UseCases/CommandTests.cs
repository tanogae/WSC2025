using Ardalis.SharedKernel;
using Clean.Architecture.ArchitectureTests.CustomRules;
using Clean.Architecture.UseCases.Contributors.Create;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;
using Xunit.Abstractions;

namespace Clean.Architecture.ArchitectureTests.UseCases;
public class CommandTests
{
  private readonly ITestOutputHelper testOutputHelper;

  public CommandTests(ITestOutputHelper testOutputHelper)
  {
    this.testOutputHelper = testOutputHelper;
  }

  [Fact]
  public void Command_Should_Be_In_UseCases_Project()
  {
    // Arrange
    // Act 
    TestResult result = Types.InAssembly(typeof(Program).Assembly, loadReferencedAssemblies:true)
                             .That()
                             .ImplementInterface(typeof(ICommand<>))
                             .Should()
                             .ResideInNamespaceContaining("Clean.Architecture.UseCases")
                             .GetResult();

    // Assert
    result.DisplayFailingTypes(this.testOutputHelper).IsSuccessful.Should().BeTrue();
  }

  [Fact]
  public void Command_Should_Have_Suffix_Command()
  {
    // Arrange
    // Act 
    TestResult result = Types.InAssembly(typeof(CreateContributorCommand).Assembly)
                             .That()
                             .ImplementInterface(typeof(ICommand<>))
                             .Should()
                             .HaveNameEndingWith("Command")
                             .GetResult();

    // Assert
    result.DisplayFailingTypes(this.testOutputHelper).IsSuccessful.Should().BeTrue();
  }

  [Fact]
  public void Command_Should_Be_Record()
  {
    // Arrange
    // Act 
    TestResult result = Types.InAssembly(typeof(CreateContributorCommand).Assembly)
                             .That()
                             .ImplementInterface(typeof(ICommand<>))
                             .Should()
                             .BeRecord()
                             .GetResult();

    // Assert
    result.DisplayFailingTypes(this.testOutputHelper).IsSuccessful.Should().BeTrue();
  }
}
