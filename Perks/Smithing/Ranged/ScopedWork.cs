using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Ranged;

[Parents(typeof(BeginnersFlame))]
public class ScopedWork : RangedPerk
{
    public ScopedWork() : base("scopedwork")
    {
    }

    public override string Name => "Scoped Work";

    protected override int RequiredSkill => 5;

    protected override int[] Unlocks { get; } = { PrefixID.Sighted, PrefixID.Intimidating };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Sighted), nameof(PrefixID.Intimidating) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 0));
}