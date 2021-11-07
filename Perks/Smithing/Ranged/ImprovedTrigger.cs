using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Ranged;

[Parents(typeof(ScopedWork))]
public class ImprovedTrigger : RangedPerk
{
    public ImprovedTrigger() : base("improvedtrigger")
    {
    }

    public override string Name => "Improved Trigger";

    protected override int RequiredSkill => 15;

    protected override int[] Unlocks { get; } = { PrefixID.Powerful, PrefixID.Rapid };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Powerful), nameof(PrefixID.Rapid) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 1));
}