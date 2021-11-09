using static Terraria.ID.PrefixID;

namespace TerrabornLeveling.Perks.Smithing.Ranged;

[Parents(typeof(BeginnersFlame))]
public class ScopedWork : RangedPerk
{
    public ScopedWork() : base("scopedwork")
    {
    }

    public override string Name => "Scoped Work";

    protected override int RequiredSkill => 15;

    protected override int[] Unlocks { get; } = { Sighted, Powerful, Rapid, Intimidating };
    protected override string[] UnlockNames { get; } = { nameof(Sighted), nameof(Powerful), nameof(Rapid), nameof(Intimidating) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 1));
}