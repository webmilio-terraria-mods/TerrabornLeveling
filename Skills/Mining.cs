using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Mining : Skill
{
    public Mining(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "mining";

    public override int Category => (int)SkillCategory.Physical;
}