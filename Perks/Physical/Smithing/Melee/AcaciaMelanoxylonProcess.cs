using TerrabornLeveling.Perks.Visualisers;
using static Terraria.ID.PrefixID;

namespace TerrabornLeveling.Perks.Physical.Smithing.Melee;

[Parents(typeof(TeenageWisdom))]
public class AcaciaMelanoxylonProcess : MeleePerk
{
    public AcaciaMelanoxylonProcess() : base("acaciamelanoxylonprocess")
    {
    }

    public override string Name => "Acacia Melanoxylon Process";

    protected override int RequiredSkill => 50;

    protected override int[] Unlocks { get; } = { Shameful, Tiny, Sharp, Massive };
    protected override string[] UnlockNames { get; } = { nameof(Shameful), nameof(Tiny), nameof(Sharp), nameof(Massive) };

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.032f, .61f));
}