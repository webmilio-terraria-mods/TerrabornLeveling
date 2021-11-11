using static Terraria.ID.PrefixID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(BeginnersFlame))]
public class CheapSteel : MeleePerk
{
    public CheapSteel() : base("cheapsteel")
    {
    }

    public override string Name => "Cheap Steel";

    protected override int RequiredSkill => 10;

    protected override int[] Unlocks { get; } = { Heavy, Light, Bulky, Pointy };
    protected override string[] UnlockNames { get; } = { nameof(Heavy), nameof(Light), nameof(Bulky), nameof(Pointy) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(.17f, .955f));
}