using NetArchTest.Rules;

namespace Clean.Architecture.ArchitectureTests.CustomRules;
public static class CustomRules
{
  public static ConditionList BeRecord(this Condition conditions)
      => conditions.MeetCustomRule(new IsRecordRule());
}
