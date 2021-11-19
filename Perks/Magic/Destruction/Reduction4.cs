using TerrabornLeveling.Perks.Visualisers;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Magic.Destruction;

[Parents(typeof(Reduction3))]
public class Reduction4 : ManaEfficiencyPerk
{
    public Reduction4() : base("reduction4", ItemRarityID.Yellow, ItemRarityID.Cyan)
    {
    }

    public override string GetDescription(int level)
    {
        return string.Format(Description, nameof(ItemRarityID.Yellow), nameof(ItemRarityID.Cyan));
    }

    public override string Name => "Reduction 4";

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.5f, .4f));
}