using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class OneHanded : Skill
{
    public OneHanded(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "onehanded";

    public override int Category => (int)SkillCategory.Physical;
}