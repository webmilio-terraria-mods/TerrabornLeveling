using TerrabornLeveling.Perks.Visualisers;
using static Terraria.ID.PrefixID;

namespace TerrabornLeveling.Perks.Physical.Smithing.Ranged;

[Parents(typeof(AssassinsArmory))]
public class ExtremeModifications : RangedPerk
{
    public ExtremeModifications() : base("extrememodifications")
    {
    }

    public override string Name => "Extreme Modifications";

    protected override int RequiredSkill => 90;

    protected override int[] Unlocks { get; } = { Awful, Unreal };
    protected override string[] UnlockNames { get; } = { nameof(Awful), nameof(Unreal) };

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.27f, .17f));
}