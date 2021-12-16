using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Fishing : Skill
{
    public Fishing(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "fishing";

    public override int Category => (int)SkillCategory.Agility;
}