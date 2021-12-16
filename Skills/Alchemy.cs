using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Alchemy : Skill
{
    public Alchemy(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "alchemy";

    public override int Category => (int)SkillCategory.Magical;
}