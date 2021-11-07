using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(DaggerCraft))]
public class AcaciaMelanoxylonProcess : MeleePerk
{
    public AcaciaMelanoxylonProcess() : base("acaciamelanoxylonprocess")
    {
    }

    public override string Name => "Acacia Melanoxylon Process";

    protected override int RequiredSkill => 55;

    protected override int[] Unlocks { get; } = { PrefixID.Shameful, PrefixID.Massive };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Shameful), nameof(PrefixID.Massive) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 5));
}