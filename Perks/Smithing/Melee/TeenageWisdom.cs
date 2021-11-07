using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(CustomFit))]
public class TeenageWisdom : MeleePerk
{
    public TeenageWisdom() : base("teenagewisdom")
    {
    }

    public override string Name => "Teenage Wisdom";

    protected override int RequiredSkill => 35;

    protected override int[] Unlocks { get; } = { PrefixID.Dull, PrefixID.Dangerous };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Dull), nameof(PrefixID.Dangerous) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 3));
}