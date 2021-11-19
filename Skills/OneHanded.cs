using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class OneHanded : Skill
{
    public OneHanded(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "onehanded";
    public override string Name => "One Handed";

    public override string Description => string.Empty;

    public override int Category => (int)SkillCategory.Physical;
}