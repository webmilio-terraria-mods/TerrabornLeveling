using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(TeenageWisdom))]
public class DaggerCraft : MeleePerk
{
    public DaggerCraft() : base("daggercraft")
    {
    }

    public override string Name => "Dagger Craft";

    protected override int RequiredSkill => 45;

    protected override int[] Unlocks { get; } = { PrefixID.Tiny, PrefixID.Sharp };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Tiny), nameof(PrefixID.Sharp) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 4));
}