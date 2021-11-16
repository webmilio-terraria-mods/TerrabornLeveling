using TerrabornLeveling.Skills;
using Terraria;

namespace TerrabornLeveling.Perks.Fishing;

[Skill(typeof(Skills.Fishing))]
public class MasterBaiter : Perk
{
    public MasterBaiter() : base("masterbaiter")
    {
    }

    public float GetFishingPowerModifier(int level) => level * .1f;

    public override void OnGetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel)
    {
        fishingLevel += FishingPowerModifier;
    }

    public override string GetDescription(int level)
    {
        return $"Increases fishing power by {(int)(GetFishingPowerModifier(level) * 100)}%.";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(1, 20, level);

    public override string Name => "Master Baiter";
    public override int MaxLevel => 5;

    public float FishingPowerModifier => GetFishingPowerModifier(Level);

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(0.5f, 0.9f));
}