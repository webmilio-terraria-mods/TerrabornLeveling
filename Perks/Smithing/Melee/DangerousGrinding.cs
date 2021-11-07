using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(AcaciaMelanoxylonProcess))]
public class DangerousGrinding : MeleePerk
{
    public DangerousGrinding() : base("dangerousgrinding")
    {
    }

    public override string Name => "Dangerous Grinding";

    protected override int RequiredSkill => 80;

    protected override int[] Unlocks { get; } = { PrefixID.Unhappy, PrefixID.Savage };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Unhappy), nameof(PrefixID.Savage) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 6));
}