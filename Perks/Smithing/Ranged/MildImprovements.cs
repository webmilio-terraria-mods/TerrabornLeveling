using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Ranged;

[Parents(typeof(Overclock))]
public class MildImprovements : RangedPerk
{
    public MildImprovements() : base("mildimprovements")
    {
    }

    public override string Name => "Mild Improvements";

    protected override int RequiredSkill => 55;

    protected override int[] Unlocks { get; } = { PrefixID.Lethargic, PrefixID.Staunch };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Lethargic), nameof(PrefixID.Staunch) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 3));
}