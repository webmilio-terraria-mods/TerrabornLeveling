using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Skills;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Magic.Destruction;

// [Skill(typeof(Skills.Destruction))]
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

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.5f, 1));
}