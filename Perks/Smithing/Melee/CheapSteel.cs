using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(BeginnersFlame))]
public class CheapSteel : MeleePerk
{
    public CheapSteel() : base("cheapsteel")
    {
    }

    public override string Name => "Cheap Steel";

    protected override int RequiredSkill => 5;

    protected override int[] Unlocks { get; } = { PrefixID.Light, PrefixID.Bulky };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Light), nameof(PrefixID.Bulky) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 0));
}