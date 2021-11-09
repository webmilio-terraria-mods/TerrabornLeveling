using TerrabornLeveling.Players;
using TerrabornLeveling.Skills;
using Terraria;

namespace TerrabornLeveling.Perks.Fishing;

[Skill(typeof(Skills.Fishing))]
public class MasterBaiter : Perk
{
    public MasterBaiter() : base("masterbaiter")
    {
    }

    public override void OnPlayerGetFishingLevel(Item fishingRod, Item bait, ref float fishingLevel)
    {
        fishingLevel += 0.05f * Level;
    }

    public override string GetDescription(int level)
    {
        return $"Increases fishing power by {level * 5}%.";
    }

    public override string Name { get; } = "Master Baiter";

    public override int MaxLevel { get; } = 5;

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(0.5f, 0.9f));
}