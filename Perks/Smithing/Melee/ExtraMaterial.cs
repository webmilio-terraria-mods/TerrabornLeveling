using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(CheapSteel))]
public class ExtraMaterial : MeleePerk
{
    public ExtraMaterial() : base("extramaterial")
    {
    }

    public override string Name => "Extra Material";

    protected override int RequiredSkill => 15;

    protected override int[] Unlocks { get; } = { PrefixID.Heavy, PrefixID.Pointy };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Heavy), nameof(PrefixID.Pointy) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 1));
}