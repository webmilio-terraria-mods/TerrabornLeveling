using Terraria.ID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(ExtraMaterial))]
public class CustomFit : MeleePerk
{
    public CustomFit() : base("customfit")
    {
    }

    public override string Name => "Custom Fit";

    protected override int RequiredSkill => 25;

    protected override int[] Unlocks { get; } = { PrefixID.Small, PrefixID.Large };
    protected override object[] UnlockNames { get; } = { nameof(PrefixID.Small), nameof(PrefixID.Large) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 2));
}