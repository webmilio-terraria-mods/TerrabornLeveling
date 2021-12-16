using TerrabornLeveling.Perks.Visualisers;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Magic.Destruction;

// [Parents(typeof(Reduction2))]
public class Reduction3 : ManaEfficiencyPerk
{
    public Reduction3() : base("reduction3", ItemRarityID.LightPurple, ItemRarityID.Lime)
    {
    }

    public override string GetDescription(int level)
    {
        return string.Format(Description, nameof(ItemRarityID.LightPurple), nameof(ItemRarityID.Lime));
    }

    public override string Name => "Reduction 3";

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.5f, .6f));
}