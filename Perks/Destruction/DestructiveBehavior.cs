using TerrabornLeveling.Perks.Magic;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Destruction;

[Skill(typeof(Skills.Destruction))]
public class DestructiveBehavior : ManaEfficiencyPerk
{
    public DestructiveBehavior() : base("destructivebehavior", ItemRarityID.Gray, ItemRarityID.Green)
    {
    }

    public override string GetDescription(int level)
    {
        return $"Reduces the mana cost of spells under Green tier by {RangeReduction * 100}%.";
    }

    public override string Name => "Destructive Behavior";

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(.5f, 1));
}