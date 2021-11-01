using System;

namespace TerrabornLeveling.Skills;

[AttributeUsage(AttributeTargets.Class)]
public class SkillAttribute : Attribute
{
    public SkillAttribute(Type skillType)
    {
        SkillType = skillType;
    }

    public Type SkillType { get; }
}