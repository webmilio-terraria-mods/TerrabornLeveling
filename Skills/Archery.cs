using System.Collections.Generic;
using TerrabornLeveling.Perks;
using Terraria.Localization;

namespace TerrabornLeveling.Skills;

public class Archery : Skill
{
    public Archery(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "archery";

    public override string Description => "";

    public override int Category => (int)SkillCategory.Agility;
}