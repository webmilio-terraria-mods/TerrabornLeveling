using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Tiles;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Physical.Mining;

[Parents(typeof(Spelunker))]
public class AlignedZAxis : Perk
{
    public AlignedZAxis() : base("alignedzaxis")
    {
    }

    public override void OnRightClickTile(int x, int y, int type)
    {
        if (!Owner.Player.IsTileTypeInInteractionRange(type))
        {
            return;
        }

        if (Owner.Player.HeldItem.pick > 0)
        {
            ModContent.GetInstance<TLGlobalTile>()
                .TryAlignZAxis(Owner, new(x, y), type);
        }
    }

    public override string GetDescription(int level)
    {
        return "Right-clicking on an ore tile while holding a pickaxe will align\n" +
               "it with it's Z-Axis vein. Can only be done once a day.";
    }

    public override string Name => "Aligned Z Axis";

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.63f, 0));
}