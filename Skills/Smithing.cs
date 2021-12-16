using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Smithing : Skill
{
    public Smithing(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "smithing";

    public override int Category => (int)SkillCategory.Physical;
}