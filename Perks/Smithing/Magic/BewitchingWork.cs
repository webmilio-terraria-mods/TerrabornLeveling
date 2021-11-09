using static Terraria.ID.PrefixID;

namespace TerrabornLeveling.Perks.Smithing.Magic;

[Parents(typeof(BeginnersFlame))]
public class BewitchingWork : MagicPerk
{
    public BewitchingWork() : base("bewitchingwork")
    {
    }

    public override string Name => "Bewitching Work";

    protected override int RequiredSkill => 5;

    protected override int[] Unlocks { get; } = { Furious, Taboo, Manic, Adept };
    protected override string[] UnlockNames { get; } = { nameof(Adept), nameof(Taboo), nameof(Manic), nameof(Adept) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 1));
}