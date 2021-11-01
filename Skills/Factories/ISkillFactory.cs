using System;

namespace TerrabornLeveling.Skills.Factories;

public interface ISkillFactory
{
    public ISkill Make(Type skillType);
}