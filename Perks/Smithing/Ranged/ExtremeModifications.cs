using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Ranged;

[Parents(typeof(AssassinsArmory))]
public class ExtremeModifications : RangedPerk
{
    public ExtremeModifications() : base("extrememodifications")
    {
    }

    public override string Name => "Extreme Modifications";

    protected override int RequiredSkill => 95;

    protected override int[] Unlocks { get; } = { PrefixID.Awful, PrefixID.Unreal };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Awful), nameof(PrefixID.Unreal) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 5));
}