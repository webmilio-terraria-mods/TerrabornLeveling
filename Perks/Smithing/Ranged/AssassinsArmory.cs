using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Ranged;

[Parents(typeof(MildImprovements))]
public class AssassinsArmory : RangedPerk
{
    public AssassinsArmory() : base("assassinsarmory")
    {
    }

    public override string Name => "Assassin's Armory";

    protected override int RequiredSkill => 75;

    protected override int[] Unlocks { get; } = { PrefixID.Awkward, PrefixID.Deadly };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Awkward), nameof(PrefixID.Deadly) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 4));
}