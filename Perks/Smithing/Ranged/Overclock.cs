using static Terraria.ID.PrefixID;

namespace TerrabornLeveling.Perks.Smithing.Ranged;

[Parents(typeof(ScopedWork))]
public class Overclock : RangedPerk
{
    public Overclock() : base("overclock")
    {
    }

    public override string Name => "Overclock";

    protected override int RequiredSkill => 40;

    protected override int[] Unlocks { get; } = { Lethargic, Frenzying, Hasty, Staunch };
    protected override string[] UnlockNames { get; } = { nameof(Lethargic), nameof(Frenzying), nameof(Hasty), nameof(Staunch) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(.26f, .55f));
}