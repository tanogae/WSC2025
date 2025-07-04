﻿using Mono.Cecil;
using NetArchTest.Rules;

namespace Clean.Architecture.ArchitectureTests.CustomRules;

public class PropertiesSetShouldNotBePublicRule : ICustomRule
{
  public bool MeetsRule(TypeDefinition type)
    => !type.Properties.Any(p => p.SetMethod != null && p.SetMethod.IsPublic);

}
