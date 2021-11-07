using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Ranged;

[Parents(typeof(ImprovedTrigger))]
public class Overclock : RangedPerk
{
    public Overclock() : base("overclock")
    {
    }

    public override string Name => "Overclock";

    protected override int RequiredSkill => 35;

    protected override int[] Unlocks { get; } = { PrefixID.Frenzying, PrefixID.Hasty };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Frenzying), nameof(PrefixID.Hasty) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 2));
}