using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(DangerousGrinding))]
public class LegendaryIntuition : MeleePerk
{
    public LegendaryIntuition() : base("legendaryintuition")
    {
    }

    public override string Name => "Legendary Intuition";

    protected override int RequiredSkill => 95;

    protected override int[] Unlocks { get; } = { PrefixID.Terrible, PrefixID.Legendary };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Terrible), nameof(PrefixID.Legendary) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 7));
}