using NetArchTest.Rules;
using Xunit.Abstractions;

namespace Clean.Architecture.ArchitectureTests;

  public static class ArchitectureTestsExtensions
  {
     public static TestResult DisplayFailingTypes(this TestResult testResult, ITestOutputHelper outputHelper)
    {
      if (!testResult.IsSuccessful)
      {
        outputHelper.WriteLine("Tipi che non soddisfano il test:");
        outputHelper.WriteLine(string.Join(Environment.NewLine, testResult.FailingTypes.Select(t => t.ReflectionType.Name)));
      }

      return testResult;
    }
  }
