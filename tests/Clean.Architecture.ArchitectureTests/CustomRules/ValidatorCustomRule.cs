using FastEndpoints;
using Mono.Cecil;
using NetArchTest.Rules;

namespace Clean.Architecture.ArchitectureTests.CustomRules;

public class ValidatorCustomRule : ICustomRule
{
  public bool MeetsRule(TypeDefinition type)
  {
    var result = Types.InAssembly(typeof(Program).Assembly)
                      .That()
                      .HaveNameMatching(type.Name.Replace("Request", "Validator"))
                      .Should()
                      .Inherit(typeof(Validator<>))
                      .GetResult();

    return result.SelectedTypesForTesting.Count == 1 && result.IsSuccessful;
  }
}
