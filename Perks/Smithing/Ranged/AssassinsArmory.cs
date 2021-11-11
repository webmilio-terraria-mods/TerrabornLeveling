using static Terraria.ID.PrefixID;

namespace TerrabornLeveling.Perks.Smithing.Ranged;

[Parents(typeof(Overclock))]
public class AssassinsArmory : RangedPerk
{
    public AssassinsArmory() : base("assassinsarmory")
    {
    }

    public override string Name => "Assassin's Armory";

    protected override int RequiredSkill => 70;

    protected override int[] Unlocks { get; } = { Awkward, Deadly };
    protected override string[] UnlockNames { get; } = { nameof(Awkward), nameof(Deadly) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(.22f, .4f));
}