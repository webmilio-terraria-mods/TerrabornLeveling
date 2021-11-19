using TerrabornLeveling.Perks.Visualisers;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Physical.Smithing.Melee;

[Parents(typeof(DangerousGrinding))]
public class LegendaryIntuition : MeleePerk
{
    public LegendaryIntuition() : base("legendaryintuition")
    {
    }

    public override string Name => "Legendary Intuition";

    protected override int RequiredSkill => 90;

    protected override int[] Unlocks { get; } = { PrefixID.Terrible, PrefixID.Legendary };
    protected override string[] UnlockNames { get; } = { nameof(PrefixID.Terrible), nameof(PrefixID.Legendary) };

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.135f, .014f));
}