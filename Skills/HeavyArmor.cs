using System;
using System.Collections.Generic;
using TerrabornLeveling.Perks;

namespace TerrabornLeveling.Skills;

public class HeavyArmor : Skill
{
    public HeavyArmor(IList<IPerk> perks) : base(perks)
    {
    }

    public override string Identifier => "heavyarmor";
    public override string Name => "Heavy Armor";

    public override string Description => String.Empty;

    public override int Category => (int)SkillCategory.Physical;
}