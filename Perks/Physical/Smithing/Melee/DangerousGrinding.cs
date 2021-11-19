using TerrabornLeveling.Perks.Visualisers;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Physical.Smithing.Melee;

[Parents(typeof(AcaciaMelanoxylonProcess))]
public class DangerousGrinding : MeleePerk
{
    public DangerousGrinding() : base("dangerousgrinding")
    {
    }

    public override string Name => "Dangerous Grinding";

    protected override int RequiredSkill => 70;

    protected override int[] Unlocks { get; } = { PrefixID.Unhappy, PrefixID.Savage };
    protected override string[] UnlockNames { get; } = { nameof(PrefixID.Unhappy), nameof(PrefixID.Savage) };

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(0, .287f));
}