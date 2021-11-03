using System;

namespace TerrabornLeveling.Skills.Mapping;

public interface IPerkMapper
{
    public Type[] GetPerkTypes(Type skillType);

    public Type GetSkillType(Type perkType);
}