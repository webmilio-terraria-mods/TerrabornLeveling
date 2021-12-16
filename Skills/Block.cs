using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Block : Skill
{
    public Block(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "block";

    public override int Category => (int)SkillCategory.Physical;
}