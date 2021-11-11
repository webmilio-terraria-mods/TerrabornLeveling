using TerrabornLeveling.Perks.Magic;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Destruction;

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

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(.5f, .4f));
}