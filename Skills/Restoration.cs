using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Restoration : Skill
{
    public Restoration(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "restoration";

    public override int Category => (int)SkillCategory.Magical;
}