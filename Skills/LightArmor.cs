using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class LightArmor : Skill
{
    public LightArmor(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "lightarmor";

    public override int Category => (int)SkillCategory.Physical;
}