using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Conjuration : Skill
{
    public Conjuration(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "conjuration";

    public override int Category => (int)SkillCategory.Magical;
}