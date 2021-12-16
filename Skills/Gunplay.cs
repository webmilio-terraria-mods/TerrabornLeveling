using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class Gunplay : Skill
{
    public Gunplay(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "gunplay";

    public override int Category => (int)SkillCategory.Agility;
}