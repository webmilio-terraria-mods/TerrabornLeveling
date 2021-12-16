using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Enchanting : Skill
{
    public Enchanting(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "enchanting";

    public override int Category => (int)SkillCategory.Magical;
}