using TerrabornLeveling.Perks.Visualisers;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Magic.Destruction;

// [Parents(typeof(Reduction4))]
public class Reduction5 : ManaEfficiencyPerk
{
    public Reduction5() : base("reduction5", ItemRarityID.Red, ItemRarityID.Purple)
    {
    }

    public override string GetDescription(int level)
    {
        return string.Format(Description, nameof(ItemRarityID.Red), nameof(ItemRarityID.Purple));
    }

    public override string Name => "Reduction 5";

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.5f, .2f));
}