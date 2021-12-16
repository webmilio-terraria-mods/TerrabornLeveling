using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Speech : Skill
{
    public Speech(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "speech";

    public override int Category => (int)SkillCategory.Agility;
}