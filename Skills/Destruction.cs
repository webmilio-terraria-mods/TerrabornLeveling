using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Destruction : Skill
{
    public Destruction(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "destruction";

    public override int Category => (int)SkillCategory.Magical;
}