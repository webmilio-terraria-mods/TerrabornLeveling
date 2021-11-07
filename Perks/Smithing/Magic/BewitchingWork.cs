using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Magic;

[Parents(typeof(BeginnersFlame))]
public class BewitchingWork : MagicPerk
{
    public BewitchingWork() : base("bewitchingwork")
    {
    }

    public override string Name => "Bewitching Work";

    protected override int RequiredSkill => 5;

    protected override int[] Unlocks { get; } = { PrefixID.Taboo, PrefixID.Manic };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Taboo), nameof(PrefixID.Manic) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 0));
}