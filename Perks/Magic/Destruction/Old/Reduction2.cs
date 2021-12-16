using TerrabornLeveling.Perks.Visualisers;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Magic.Destruction;

// [Parents(typeof(DestructiveBehavior))]
public class Reduction2 : ManaEfficiencyPerk
{
    public Reduction2() : base("reduction2", ItemRarityID.LightRed, ItemRarityID.Pink)
    {
    }

    public override string GetDescription(int level)
    {
        return string.Format(Description, nameof(ItemRarityID.LightRed), nameof(ItemRarityID.Pink));
    }

    public override string Name => "Reduction 2";

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.5f, .8f));
}