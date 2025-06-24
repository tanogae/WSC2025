using Mono.Cecil;
using Mono.Cecil.Rocks;
using NetArchTest.Rules;

namespace Clean.Architecture.ArchitectureTests.CustomRules;

  public class IsRecordRule : ICustomRule
  {   
    public bool MeetsRule(TypeDefinition type)
        => type.GetMethods().Any(m => m.Name == "<Clone>$");
  }
