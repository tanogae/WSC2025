using Mono.Cecil;
using NetArchTest.Rules;

namespace Clean.Architecture.ArchitectureTests.CustomRules;

public class DefaultCtorShouldNotBePublicRule : ICustomRule
{
  public bool MeetsRule(TypeDefinition type)
    => !type.Methods.Any(m => m.IsConstructor && !m.HasParameters && m.IsPublic);
}
